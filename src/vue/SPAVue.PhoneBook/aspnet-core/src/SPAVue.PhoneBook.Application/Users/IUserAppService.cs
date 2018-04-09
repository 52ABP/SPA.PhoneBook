using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPAVue.PhoneBook.Roles.Dto;
using SPAVue.PhoneBook.Users.Dto;

namespace SPAVue.PhoneBook.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
