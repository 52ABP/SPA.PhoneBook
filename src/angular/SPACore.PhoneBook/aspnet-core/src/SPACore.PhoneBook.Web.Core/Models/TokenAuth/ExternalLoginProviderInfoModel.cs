using Abp.AutoMapper;
using SPACore.PhoneBook.Authentication.External;

namespace SPACore.PhoneBook.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
