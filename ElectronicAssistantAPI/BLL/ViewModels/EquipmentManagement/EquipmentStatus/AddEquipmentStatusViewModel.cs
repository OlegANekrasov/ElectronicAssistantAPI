using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.EquipmentStatus
{
    public class AddEquipmentStatusViewModel
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
