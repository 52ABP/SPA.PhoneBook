using AutoMapper;

namespace SPACore.PhoneBook.Persons.Dtos.LTMAutoMapper
{
    using SPACore.PhoneBook.PhoneBooks.Persons;

    /// <summary>
    /// 配置Person的AutoMapper
    /// </summary>
    internal static class CustomerPersonMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Person, PersonDto>();
            configuration.CreateMap<Person, PersonListDto>();
            configuration.CreateMap<PersonEditDto, Person>();
            // configuration.CreateMap<CreatePersonInput, Person>();
            //        configuration.CreateMap<Person, GetPersonForEditOutput>();
        }
    }
}