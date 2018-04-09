using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.Roles.Dto;
using SPACore.PhoneBook.Users.Dto;

namespace SPACore.PhoneBook.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
