using ElectronicAssistantAPI.BLL.Models.CommonData;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.DAL.EF;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.DAL.Repository.EquipmentManagement
{
    public class EquipmentStatusRepository : Repository<EquipmentStatus>
    {
        public EquipmentStatusRepository(ApplicationDbContext db) : base(db)
        {
           
        }

        public IEnumerable<EquipmentStatus> GetEquipmentStatuses()
        {
            return base.Get();
        }

        public async Task<EquipmentStatus> GetEquipmentStatusByIdAsync(string id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<EquipmentStatus> AddEquipmentStatusAsync(AddEquipmentStatus model)
        {
            var equipmentStatus = new EquipmentStatus()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
            };

            await CreateAsync(equipmentStatus);
            return equipmentStatus;
        }

        public async Task<EquipmentStatus> UpdateEquipmentStatusAsync(UpdateEquipmentStatus model)
        {
            var equipmentStatus = await GetByIdAsync(model.Id);
            if (equipmentStatus != null)
            {
                equipmentStatus.Name = model.Name;
                equipmentStatus.Description = model.Description;

                await UpdateAsync(equipmentStatus);
                return equipmentStatus;
            }

            return null;
        }

        public async Task DeleteEquipmentStatusAsync(string id)
        {
            await DeleteAsync(id);
        }
    }
}
