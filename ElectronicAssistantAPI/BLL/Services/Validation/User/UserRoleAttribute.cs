using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.Services.Validation.User
{
    public class UserRoleAttribute : ValidationAttribute
    {
        public UserRoleAttribute() { }

        public override bool IsValid(object? value)
        {
            var userRoles = value as IEnumerable<UserRole>;
            return userRoles.Where(o => o.IsRoleAssigned).Any();
        }
    }
}
