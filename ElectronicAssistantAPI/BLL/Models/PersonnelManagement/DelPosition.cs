using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.Models.PersonnelManagement
{
    public class DelPosition
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
