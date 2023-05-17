using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.BLL.Models.EquipmentManagement.Characteristic
{
    public class UpdateCharacteristic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TypesValues TypeValue { get; set; }
        public string? Description { get; set; }
    }
}
