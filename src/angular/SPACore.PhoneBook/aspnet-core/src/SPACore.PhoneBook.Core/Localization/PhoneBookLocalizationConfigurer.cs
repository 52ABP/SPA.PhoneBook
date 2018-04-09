using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SPACore.PhoneBook.Localization
{
    public static class PhoneBookLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PhoneBookConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PhoneBookLocalizationConfigurer).GetAssembly(),
                        "SPACore.PhoneBook.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
