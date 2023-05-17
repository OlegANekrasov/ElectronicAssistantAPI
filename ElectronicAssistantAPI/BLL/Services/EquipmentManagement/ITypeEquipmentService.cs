using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.TypeEquipment;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.BLL.Services.EquipmentManagement
{
    public interface ITypeEquipmentService
    {
        IEnumerable<TypeEquipment> Get();
        Task<TypeEquipment> GetByIdAsync(string id);
        Task<TypeEquipment> AddAsync(AddTypeEquipment model);
        Task<TypeEquipment> UpdateAsync(UpdateTypeEquipment model);
        Task DeleteAsync(DelTypeEquipment model);
    }
}
