using System;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.Persons.Dtos.LTMAutoMapper;
using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons.Dtos
{
    public class PersonListDto : FullAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
    }
}