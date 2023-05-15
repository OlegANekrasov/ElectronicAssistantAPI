using ElectronicAssistantAPI.BLL.Services.Validation.User;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement
{
    public class UpdateUserRoleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор пользователя")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Роли")]
        [UserRole(ErrorMessage = "Пользователю не назначена роль.")]
        public List<UserRole> Roles { get; set; }
    }
}
