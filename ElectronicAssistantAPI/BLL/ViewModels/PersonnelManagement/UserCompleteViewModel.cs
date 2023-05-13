using ElectronicAssistantAPI.DAL.Models.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement
{
    public class UserCompleteViewModel
    {
        public string UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName => Email;
        public string? PhoneNumber { get; set; }
        public byte[]? Image { get; set; }
        public string? About { get; set; }
        public string? Position { get; set; }
        public List<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
