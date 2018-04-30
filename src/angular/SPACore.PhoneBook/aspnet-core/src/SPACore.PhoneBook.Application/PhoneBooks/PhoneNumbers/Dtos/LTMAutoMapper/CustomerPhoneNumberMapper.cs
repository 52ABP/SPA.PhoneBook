using AutoMapper;

namespace SPACore.PhoneBook.PhoneBooks.PhoneNumbers.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置PhoneNumber的AutoMapper
    /// </summary>
    internal static class CustomerPhoneNumberMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <PhoneNumber, PhoneNumberDto>();
            configuration.CreateMap<PhoneNumber, PhoneNumberListDto>();
            configuration.CreateMap<PhoneNumberEditDto, PhoneNumber>();
            // configuration.CreateMap<CreatePhoneNumberInput, PhoneNumber>();
            //        configuration.CreateMap<PhoneNumber, GetPhoneNumberForEditOutput>();
        }
    }
}