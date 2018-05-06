using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SPACore.PhoneBook.Authorization;
using SPACore.PhoneBook.Persons.Authorization;
using SPACore.PhoneBook.Persons.Dtos.LTMAutoMapper;

namespace SPACore.PhoneBook
{
    [DependsOn(
        typeof(PhoneBookCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PhoneBookApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PhoneBookAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PersonAppAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPersonMapper.CreateMappings);

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PhoneBookApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
