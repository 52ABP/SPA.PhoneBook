using System.Threading.Tasks;
using Abp.Application.Services;
using SPACore.PhoneBook.Sessions.Dto;

namespace SPACore.PhoneBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
