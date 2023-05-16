using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicAssistantAPI.DAL.Models.EquipmentManagement
{
    [Table("EquipmentFeatures")]
    public class EquipmentFeature
    {
        public string Id { get; set; }

        public string? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public string? CharacteristicId { get; set; }
        public Characteristic? Characteristic { get; set; }

        public TypesValues? TypeValue { get; set; }

        public bool? BoolValue { get; set; }

        public int? IntValue { get; set; }

        public decimal? DecimalValue { get; set; }

        public string? StringValue { get; set; }

        public DateTime? DateTimeValue { get; set; }
    }
}
