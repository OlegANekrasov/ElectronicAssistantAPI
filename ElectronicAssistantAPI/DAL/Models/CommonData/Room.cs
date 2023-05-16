using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicAssistantAPI.DAL.Models.CommonData
{
    [Table("Rooms")]
    public class Room
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Equipment> Equipments { get; set; }
    }
}
