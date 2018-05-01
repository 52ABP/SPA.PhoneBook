using System;
using Abp.Application.Services.Dto;

namespace SPACore.PhoneBook.PhoneBooks.PhoneNumbers.Dtos
{
    public class PhoneNumberListDto : EntityDto<long>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Number { get; set; }
        public int PersonId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType Type { get; set; }
        public DateTime CreationTime { get; set; }
    }
}