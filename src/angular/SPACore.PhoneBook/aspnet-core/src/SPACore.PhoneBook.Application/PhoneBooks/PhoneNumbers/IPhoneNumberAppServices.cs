using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.PhoneBooks.PhoneNumbers.Dtos;

namespace SPACore.PhoneBook.PhoneBooks.PhoneNumbers
{
    /// <summary>
    /// PhoneNumber应用层服务的接口方法
    /// </summary>
    public interface IPhoneNumberAppService : IApplicationService
    {
        /// <summary>
        /// 获取PhoneNumber的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PhoneNumberListDto>> GetPagedPhoneNumbers(GetPhoneNumbersInput input);

        /// <summary>
        /// 通过指定id获取PhoneNumberListDto信息
        /// </summary>
        Task<PhoneNumberListDto> GetPhoneNumberByIdAsync(EntityDto<long> input);

        /// <summary>
        /// 导出PhoneNumber为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetPhoneNumbersToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPhoneNumberForEditOutput> GetPhoneNumberForEdit(NullableIdDto<long> input);

        //todo:缺少Dto的生成GetPhoneNumberForEditOutput
        /// <summary>
        /// 添加或者修改PhoneNumber的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdatePhoneNumber(CreateOrUpdatePhoneNumberInput input);

        /// <summary>
        /// 删除PhoneNumber信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeletePhoneNumber(EntityDto<long> input);

        /// <summary>
        /// 批量删除PhoneNumber
        /// </summary>
        Task BatchDeletePhoneNumbersAsync(List<long> input);
    }
}
