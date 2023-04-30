using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement
{
    public class UpdatePositionViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание")]
        public string? Description { get; set; }
    }
}
