using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.Characteristic;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.BLL.Services.EquipmentManagement
{
    public interface ICharacteristicService
    {
        IEnumerable<Characteristic> Get();
        Task<Characteristic> GetByIdAsync(string id);
        Task<Characteristic> AddAsync(AddCharacteristic model);
        Task<Characteristic> UpdateAsync(UpdateCharacteristic model);
        Task DeleteAsync(DelCharacteristic model);
    }
}
