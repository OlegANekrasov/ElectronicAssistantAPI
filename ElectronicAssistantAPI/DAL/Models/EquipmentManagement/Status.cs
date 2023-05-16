using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicAssistantAPI.DAL.Models.EquipmentManagement
{
    [Table("Statuses")]
    public class Status
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Equipment> Equipments { get; set; }
    }
}
