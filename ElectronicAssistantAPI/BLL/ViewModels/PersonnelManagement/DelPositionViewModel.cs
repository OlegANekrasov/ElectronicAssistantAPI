using System.ComponentModel.DataAnnotations;

namespace ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement
{
    public class DelPositionViewModel
    {
        [Required]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
