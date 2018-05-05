using System.ComponentModel.DataAnnotations;

namespace SPACore.PhoneBook.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}