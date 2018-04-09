using System.Threading.Tasks;
using SPACore.PhoneBook.Configuration.Dto;

namespace SPACore.PhoneBook.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
