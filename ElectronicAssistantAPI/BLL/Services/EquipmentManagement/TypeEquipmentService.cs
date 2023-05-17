using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Services.CommonData;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using ElectronicAssistantAPI.DAL.Repository.EquipmentManagement;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.TypeEquipment;

namespace ElectronicAssistantAPI.BLL.Services.EquipmentManagement
{
    public class TypeEquipmentService : ITypeEquipmentService
    {
        private readonly IRepository<TypeEquipment> _typeEquipmentRepository;
        private readonly ILogger<RoomService> _logger;

        public TypeEquipmentService(IRepository<TypeEquipment> typeEquipmentRepository, ILogger<RoomService> logger)
        {
            _typeEquipmentRepository = typeEquipmentRepository;
            _logger = logger;
        }

        public IEnumerable<TypeEquipment> Get()
        {
            return ((TypeEquipmentRepository)_typeEquipmentRepository).GetTypesEquipment();
        }

        public async Task<TypeEquipment> GetByIdAsync(string id)
        {
            return await ((TypeEquipmentRepository)_typeEquipmentRepository).GetTypeEquipmentByIdAsync(id);
        }

        public async Task<TypeEquipment> AddAsync(AddTypeEquipment model)
        {
            return await ((TypeEquipmentRepository)_typeEquipmentRepository).AddTypeEquipmentAsync(model);
        }

        public async Task<TypeEquipment> UpdateAsync(UpdateTypeEquipment model)
        {
            return await ((TypeEquipmentRepository)_typeEquipmentRepository).UpdateTypeEquipmentAsync(model);
        }

        public async Task DeleteAsync(DelTypeEquipment model)
        {
            await ((TypeEquipmentRepository)_typeEquipmentRepository).DeleteTypeEquipmentAsync(model.Id);
        }
    }
}
