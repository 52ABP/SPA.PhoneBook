using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace SPACore.PhoneBook.PhoneBooks.Persons.Dtos
{
    public class GetPersonForEditOutput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        public PersonEditDto Person { get; set; }


    public List<ComboboxItemDto> PhoneNumberType { get; set; }
}
}