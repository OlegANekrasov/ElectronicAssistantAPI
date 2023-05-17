using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Services.CommonData;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using ElectronicAssistantAPI.DAL.Repository.EquipmentManagement;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.Characteristic;

namespace ElectronicAssistantAPI.BLL.Services.EquipmentManagement
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly IRepository<Characteristic> _characteristicRepository;
        private readonly ILogger<RoomService> _logger;

        public CharacteristicService(IRepository<Characteristic> characteristicRepository, ILogger<RoomService> logger)
        {
            _characteristicRepository = characteristicRepository;
            _logger = logger;
        }

        public IEnumerable<Characteristic> Get()
        {
            return ((CharacteristicRepository)_characteristicRepository).GetCharacteristic();
        }

        public async Task<Characteristic> GetByIdAsync(string id)
        {
            return await ((CharacteristicRepository)_characteristicRepository).GetCharacteristicByIdAsync(id);
        }

        public async Task<Characteristic> AddAsync(AddCharacteristic model)
        {
            return await ((CharacteristicRepository)_characteristicRepository).AddCharacteristicAsync(model);
        }

        public async Task<Characteristic> UpdateAsync(UpdateCharacteristic model)
        {
            return await ((CharacteristicRepository)_characteristicRepository).UpdateCharacteristicAsync(model);
        }

        public async Task DeleteAsync(DelCharacteristic model)
        {
            await ((CharacteristicRepository)_characteristicRepository).DeleteCharacteristicAsync(model.Id);
        }
    }
}
