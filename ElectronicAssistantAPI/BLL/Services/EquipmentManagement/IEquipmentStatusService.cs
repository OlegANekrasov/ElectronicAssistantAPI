using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.BLL.Services.EquipmentManagement
{
    public interface IEquipmentStatusService
    {
        IEnumerable<EquipmentStatus> Get();
        Task<EquipmentStatus> GetByIdAsync(string id);
        Task<EquipmentStatus> AddAsync(AddEquipmentStatus model);
        Task<EquipmentStatus> UpdateAsync(UpdateEquipmentStatus model);
        Task DeleteAsync(DelEquipmentStatus model);
    }
}
