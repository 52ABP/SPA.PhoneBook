using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using SPACore.PhoneBook.MultiTenancy;

namespace SPACore.PhoneBook.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
