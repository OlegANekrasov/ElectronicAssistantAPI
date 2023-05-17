using ElectronicAssistantAPI.BLL.Models.CommonData;
using ElectronicAssistantAPI.BLL.Services.CommonData;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Repository.CommonData;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using ElectronicAssistantAPI.DAL.Repository.EquipmentManagement;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;

namespace ElectronicAssistantAPI.BLL.Services.EquipmentManagement
{
    public class EquipmentStatusService : IEquipmentStatusService
    {
        private readonly IRepository<EquipmentStatus> _equipmentStatusRepository;
        private readonly ILogger<RoomService> _logger;

        public EquipmentStatusService(IRepository<EquipmentStatus> equipmentStatusRepository, ILogger<RoomService> logger)
        {
            _equipmentStatusRepository = equipmentStatusRepository;
            _logger = logger;
        }

        public IEnumerable<EquipmentStatus> Get()
        {
            return ((EquipmentStatusRepository)_equipmentStatusRepository).GetEquipmentStatuses();
        }

        public async Task<EquipmentStatus> GetByIdAsync(string id)
        {
            return await ((EquipmentStatusRepository)_equipmentStatusRepository).GetEquipmentStatusByIdAsync(id);
        }

        public async Task<EquipmentStatus> AddAsync(AddEquipmentStatus model)
        {
            return await ((EquipmentStatusRepository)_equipmentStatusRepository).AddEquipmentStatusAsync(model);
        }

        public async Task<EquipmentStatus> UpdateAsync(UpdateEquipmentStatus model)
        {
            return await ((EquipmentStatusRepository)_equipmentStatusRepository).UpdateEquipmentStatusAsync(model);
        }

        public async Task DeleteAsync(DelEquipmentStatus model)
        {
            await ((EquipmentStatusRepository)_equipmentStatusRepository).DeleteEquipmentStatusAsync(model.Id);
        }
    }
}
