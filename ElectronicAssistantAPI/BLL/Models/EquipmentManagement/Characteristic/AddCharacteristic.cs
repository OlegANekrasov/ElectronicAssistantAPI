using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.BLL.Models.EquipmentManagement.Characteristic
{
    public class AddCharacteristic
    {
        public string Name { get; set; }
        public TypesValues TypeValue { get; set; }
        public string? Description { get; set; }
    }
}
