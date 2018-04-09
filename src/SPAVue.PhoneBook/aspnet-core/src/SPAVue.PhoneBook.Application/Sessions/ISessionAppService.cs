using System.Threading.Tasks;
using Abp.Application.Services;
using SPAVue.PhoneBook.Sessions.Dto;

namespace SPAVue.PhoneBook.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
