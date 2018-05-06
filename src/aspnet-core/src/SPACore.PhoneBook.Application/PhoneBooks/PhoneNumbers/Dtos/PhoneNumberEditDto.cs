using System;
using System.ComponentModel.DataAnnotations;

namespace SPACore.PhoneBook.PhoneBooks.PhoneNumbers.Dtos
{
    public class PhoneNumberEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public long? Id { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }
        public PhoneNumberType Type { get; set; }
        public int PersonId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}