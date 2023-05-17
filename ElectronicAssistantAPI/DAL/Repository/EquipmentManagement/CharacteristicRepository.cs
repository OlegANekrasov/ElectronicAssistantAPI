using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.Characteristic;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.DAL.EF;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.DAL.Repository.EquipmentManagement
{
    public class CharacteristicRepository : Repository<Characteristic>
    {
        public CharacteristicRepository(ApplicationDbContext db) : base(db)
        {

        }

        public IEnumerable<Characteristic> GetCharacteristic()
        {
            return base.Get();
        }

        public async Task<Characteristic> GetCharacteristicByIdAsync(string id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<Characteristic> AddCharacteristicAsync(AddCharacteristic model)
        {
            var characteristic = new Characteristic()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
                TypeValue = model.TypeValue
            };

            await CreateAsync(characteristic);
            return characteristic;
        }

        public async Task<Characteristic> UpdateCharacteristicAsync(UpdateCharacteristic model)
        {
            var characteristic = await GetByIdAsync(model.Id);
            if (characteristic != null)
            {
                characteristic.Name = model.Name;
                characteristic.Description = model.Description;
                characteristic.TypeValue = model.TypeValue; 

                await UpdateAsync(characteristic);
                return characteristic;
            }

            return null;
        }

        public async Task DeleteCharacteristic(string id)
        {
            await DeleteAsync(id);
        }
    }
}
