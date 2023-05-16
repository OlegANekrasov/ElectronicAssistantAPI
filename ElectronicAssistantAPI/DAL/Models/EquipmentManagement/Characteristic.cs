using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicAssistantAPI.DAL.Models.EquipmentManagement
{
    [Table("Characteristics")]
    public class Characteristic
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public TypesValues? TypeValue { get; set; }

        public string TypeEquipmentId { get; set; }
        public TypeEquipment TypeEquipment { get; set; }
    }
}
