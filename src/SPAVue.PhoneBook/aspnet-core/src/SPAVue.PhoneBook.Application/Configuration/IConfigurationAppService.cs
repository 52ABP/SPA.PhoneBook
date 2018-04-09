using System.Threading.Tasks;
using SPAVue.PhoneBook.Configuration.Dto;

namespace SPAVue.PhoneBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
