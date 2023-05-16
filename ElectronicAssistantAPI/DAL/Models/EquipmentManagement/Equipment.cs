using ElectronicAssistantAPI.DAL.Models.CommonData;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicAssistantAPI.DAL.Models.EquipmentManagement
{
    [Table("Equipments")]
    public class Equipment
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public byte[]? Image { get; set; }

        public string? Description { get; set; }

        public string RoomId { get; set; }
        public Room? Room { get; set; }

        public string StatusId { get; set; }
        public Status? Status { get; set; }

        public string TypeEquipmentId { get; set; }
        public TypeEquipment? TypeEquipment { get; set; }

        public List<EquipmentFeature> EquipmentFeature { get; set; }
    }
}
