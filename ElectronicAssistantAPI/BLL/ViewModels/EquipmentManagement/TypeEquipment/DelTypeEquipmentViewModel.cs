using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.TypeEquipment
{
    public class DelTypeEquipmentViewModel
    {
        [Required]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}
