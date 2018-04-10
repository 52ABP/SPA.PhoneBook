using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using SPACore.PhoneBook.Persons.Authorization;
using SPACore.PhoneBook.Persons.Dtos;
using SPACore.PhoneBook.Persons.DomainServices;
using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons
{
    /// <summary>
    /// Person应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(PersonAppPermissions.Person)]
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Person, int> _personRepository;
        private readonly IPersonManager _personManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PersonAppService(IRepository<Person, int> personRepository
      , IPersonManager personManager
        )
        {
            _personRepository = personRepository;
            _personManager = personManager;
        }

        /// <summary>
        /// 获取Person的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PersonListDto>> GetPagedPersons(GetPersonsInput input)
        {

            var query = _personRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var personCount = await query.CountAsync();

            var persons = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            //var personListDtos = ObjectMapper.Map<List <PersonListDto>>(persons);
            var personListDtos = persons.MapTo<List<PersonListDto>>();

            return new PagedResultDto<PersonListDto>(
                personCount,
                personListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取PersonListDto信息
        /// </summary>
        public async Task<PersonListDto> GetPersonByIdAsync(EntityDto<int> input)
        {
            var entity = await _personRepository.GetAsync(input.Id);

            return entity.MapTo<PersonListDto>();
        }

        /// <summary>
        /// 导出Person为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetPersonsToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetPersonForEditOutput> GetPersonForEdit(NullableIdDto<int> input)
        {
            var output = new GetPersonForEditOutput();
            PersonEditDto personEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAsync(input.Id.Value);

                personEditDto = entity.MapTo<PersonEditDto>();

                //personEditDto = ObjectMapper.Map<List <personEditDto>>(entity);
            }
            else
            {
                personEditDto = new PersonEditDto();
            }

            output.Person = personEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Person的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdatePerson(CreateOrUpdatePersonInput input)
        {

            if (input.Person.Id.HasValue)
            {
                await UpdatePersonAsync(input.Person);
            }
            else
            {
                await CreatePersonAsync(input.Person);
            }
        }

        /// <summary>
        /// 新增Person
        /// </summary>
        [AbpAuthorize(PersonAppPermissions.Person_CreatePerson)]
        protected virtual async Task<PersonEditDto> CreatePersonAsync(PersonEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<Person>(input);

            entity = await _personRepository.InsertAsync(entity);
            return entity.MapTo<PersonEditDto>();
        }

        /// <summary>
        /// 编辑Person
        /// </summary>
        [AbpAuthorize(PersonAppPermissions.Person_EditPerson)]
        protected virtual async Task UpdatePersonAsync(PersonEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _personRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _personRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Person信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PersonAppPermissions.Person_DeletePerson)]
        public async Task DeletePerson(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _personRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Person的方法
        /// </summary>
        [AbpAuthorize(PersonAppPermissions.Person_BatchDeletePersons)]
        public async Task BatchDeletePersonsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _personRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

