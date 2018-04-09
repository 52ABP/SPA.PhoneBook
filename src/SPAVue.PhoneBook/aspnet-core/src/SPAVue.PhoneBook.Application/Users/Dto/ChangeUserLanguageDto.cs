using System.ComponentModel.DataAnnotations;

namespace SPAVue.PhoneBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}