using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPACore.PhoneBook.PhoneBooks.PhoneNumbers;

namespace SPACore.PhoneBook.PhoneNumbers.Dtos
{
    public class CreateOrUpdatePhoneNumberInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PhoneNumberEditDto PhoneNumber { get; set; }

}
}