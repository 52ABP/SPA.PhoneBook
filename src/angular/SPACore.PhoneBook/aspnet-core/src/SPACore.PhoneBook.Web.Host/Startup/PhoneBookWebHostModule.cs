using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPACore.PhoneBook.Configuration;

namespace SPACore.PhoneBook.Web.Host.Startup
{
    [DependsOn(
       typeof(PhoneBookWebCoreModule))]
    public class PhoneBookWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PhoneBookWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhoneBookWebHostModule).GetAssembly());
        }
    }
}
