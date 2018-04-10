using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Persons.Dtos
{
    public class CreateOrUpdatePersonInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PersonEditDto Person { get; set; }

}
}