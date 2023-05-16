using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicAssistantAPI.DAL.Models.EquipmentManagement
{
    [Table("TypesEquipment")]
    public class TypeEquipment
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Equipment> Equipments { get; set; }
        public List<Characteristic> Characteristics { get; set; }
    }
}
