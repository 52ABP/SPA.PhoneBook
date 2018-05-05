using System.Threading.Tasks;
using Abp.Application.Services;
using SPACore.PhoneBook.Authorization.Accounts.Dto;

namespace SPACore.PhoneBook.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
