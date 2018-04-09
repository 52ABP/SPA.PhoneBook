using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPAVue.PhoneBook.MultiTenancy.Dto;

namespace SPAVue.PhoneBook.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
