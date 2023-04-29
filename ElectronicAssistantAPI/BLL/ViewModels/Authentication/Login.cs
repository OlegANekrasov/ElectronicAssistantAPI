using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.Authentication
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")] 
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
