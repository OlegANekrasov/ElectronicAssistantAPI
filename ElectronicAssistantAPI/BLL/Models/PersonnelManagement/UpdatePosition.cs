using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.Models.PersonnelManagement
{
    public class UpdatePosition
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
