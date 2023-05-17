using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.EquipmentStatus
{
    public class DelEquipmentStatusViewModel
    {
        [Required]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
