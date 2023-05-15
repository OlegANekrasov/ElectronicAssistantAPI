using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.Models.PersonnelManagement
{
    public class UpdateUserPassword
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
