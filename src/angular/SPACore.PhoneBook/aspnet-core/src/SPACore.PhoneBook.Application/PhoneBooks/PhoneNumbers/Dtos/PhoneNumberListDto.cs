using System;
using Abp.Application.Services.Dto;
using SPACore.PhoneBook.PhoneNumbers.Dtos.LTMAutoMapper;
using SPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace SPACore.PhoneBook.PhoneNumbers.Dtos
{
    public class PhoneNumberListDto : EntityDto<long>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Number { get; set; }
        public int PersonId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}