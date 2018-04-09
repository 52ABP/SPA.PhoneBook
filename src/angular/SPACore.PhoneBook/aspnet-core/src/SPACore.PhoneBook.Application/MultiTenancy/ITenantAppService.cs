using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.MultiTenancy.Dto;

namespace SPACore.PhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
