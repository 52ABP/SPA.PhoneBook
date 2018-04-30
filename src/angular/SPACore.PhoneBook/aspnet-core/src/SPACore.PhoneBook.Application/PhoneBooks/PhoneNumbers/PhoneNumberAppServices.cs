using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

using SPACore.PhoneBook.PhoneNumbers.Dtos;
using SPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace SPACore.PhoneBook.PhoneNumbers
{
    /// <summary>
    /// PhoneNumber应用层服务的接口实现方法
    /// </summary>

    public class PhoneNumberAppService : PhoneBookAppServiceBase, IPhoneNumberAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<PhoneNumber, long> _phonenumberRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PhoneNumberAppService(IRepository<PhoneNumber, long> phonenumberRepository

            )
        {
            _phonenumberRepository = phonenumberRepository;

        }

        /// <summary>
        /// 获取PhoneNumber的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PhoneNumberListDto>> GetPagedPhoneNumbers(GetPhoneNumbersInput input)
        {

            var query = _phonenumberRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var phonenumberCount = await query.CountAsync();

            var phonenumbers = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var phonenumberListDtos = ObjectMapper.Map<List <PhoneNumberListDto>>(phonenumbers);
            var phonenumberListDtos = phonenumbers.MapTo<List<PhoneNumberListDto>>();

            return new PagedResultDto<PhoneNumberListDto>(
                phonenumberCount,
                phonenumberListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取PhoneNumberListDto信息
        /// </summary>
        public async Task<PhoneNumberListDto> GetPhoneNumberByIdAsync(EntityDto<long> input)
        {
            var entity = await _phonenumberRepository.GetAsync(input.Id);

            return entity.MapTo<PhoneNumberListDto>();
        }

        /// <summary>
        /// 导出PhoneNumber为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetPhoneNumbersToExcel(){
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
        public async Task<GetPhoneNumberForEditOutput> GetPhoneNumberForEdit(NullableIdDto<long> input)
        {
            var output = new GetPhoneNumberForEditOutput();
            PhoneNumberEditDto phonenumberEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _phonenumberRepository.GetAsync(input.Id.Value);

                phonenumberEditDto = entity.MapTo<PhoneNumberEditDto>();

                //phonenumberEditDto = ObjectMapper.Map<List <phonenumberEditDto>>(entity);
            }
            else
            {
                phonenumberEditDto = new PhoneNumberEditDto();
            }

            output.PhoneNumber = phonenumberEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改PhoneNumber的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdatePhoneNumber(CreateOrUpdatePhoneNumberInput input)
        {

            if (input.PhoneNumber.Id.HasValue)
            {
                await UpdatePhoneNumberAsync(input.PhoneNumber);
            }
            else
            {
                await CreatePhoneNumberAsync(input.PhoneNumber);
            }
        }

        /// <summary>
        /// 新增PhoneNumber
        /// </summary>

        protected virtual async Task<PhoneNumberEditDto> CreatePhoneNumberAsync(PhoneNumberEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<PhoneNumber>(input);

            entity = await _phonenumberRepository.InsertAsync(entity);
            return entity.MapTo<PhoneNumberEditDto>();
        }

        /// <summary>
        /// 编辑PhoneNumber
        /// </summary>

        protected virtual async Task UpdatePhoneNumberAsync(PhoneNumberEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _phonenumberRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _phonenumberRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除PhoneNumber信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public async Task DeletePhoneNumber(EntityDto<long> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _phonenumberRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除PhoneNumber的方法
        /// </summary>

        public async Task BatchDeletePhoneNumbersAsync(List<long> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _phonenumberRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

