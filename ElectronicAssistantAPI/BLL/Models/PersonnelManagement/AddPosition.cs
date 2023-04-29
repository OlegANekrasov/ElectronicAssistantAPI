using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.Models.PersonnelManagement
{
    public class AddPosition
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
