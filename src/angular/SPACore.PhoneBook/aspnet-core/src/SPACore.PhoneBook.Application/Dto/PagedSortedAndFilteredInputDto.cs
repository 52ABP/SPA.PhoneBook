using SPACore.PhoneBook.PhoneBooks.Persons;

namespace SPACore.PhoneBook.Dto
{
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Filter { get; set; }
    }
}