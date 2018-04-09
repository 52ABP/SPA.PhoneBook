using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.Roles.Dto;

namespace SPACore.PhoneBook.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
