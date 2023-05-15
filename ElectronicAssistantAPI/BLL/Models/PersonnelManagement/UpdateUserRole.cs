using ElectronicAssistantAPI.BLL.Services.Validation.User;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.Models.PersonnelManagement
{
    public class UpdateUserRole
    {
        public string Id { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
