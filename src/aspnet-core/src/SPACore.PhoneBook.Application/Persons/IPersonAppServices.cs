using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.Persons.Dtos;
using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons
{
    /// <summary>
    /// Person应用层服务的接口方法
    /// </summary>
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
        /// 获取Person的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPagedPersons(GetPersonsInput input);

        /// <summary>
        /// 通过指定id获取PersonListDto信息
        /// </summary>
        Task<PersonListDto> GetPersonByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出Person为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetPersonsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPersonForEditOutput> GetPersonForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetPersonForEditOutput
        /// <summary>
        /// 添加或者修改Person的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdatePerson(CreateOrUpdatePersonInput input);

        /// <summary>
        /// 删除Person信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePerson(EntityDto<int> input);

        /// <summary>
        /// 批量删除Person
        /// </summary>
        Task BatchDeletePersonsAsync(List<int> input);
    }
}
