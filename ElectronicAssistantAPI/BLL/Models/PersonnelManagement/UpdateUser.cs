using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.Models.PersonnelManagement
{
    public class UpdateUser
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName => Email;
        public string? PhoneNumber { get; set; }
        public byte[]? Image { get; set; }
        public string? About { get; set; }
        public string? PositionId { get; set; }
    }
}
