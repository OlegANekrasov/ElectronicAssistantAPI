using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement
{
    public class AddPositionViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание")]
        public string? Description { get; set; }
    }
}
