using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.TypeEquipment;
using ElectronicAssistantAPI.DAL.EF;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;

namespace ElectronicAssistantAPI.DAL.Repository.EquipmentManagement
{
    public class TypeEquipmentRepository : Repository<TypeEquipment>
    {
        public TypeEquipmentRepository(ApplicationDbContext db) : base(db)
        {

        }

        public IEnumerable<TypeEquipment> GetTypesEquipment()
        {
            return base.Get();
        }

        public async Task<TypeEquipment> GetTypeEquipmentByIdAsync(string id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<TypeEquipment> AddTypeEquipmentAsync(AddTypeEquipment model)
        {
            var typeEquipment = new TypeEquipment()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
            };

            await CreateAsync(typeEquipment);
            return typeEquipment;
        }

        public async Task<TypeEquipment> UpdateTypeEquipmentAsync(UpdateTypeEquipment model)
        {
            var typeEquipment = await GetByIdAsync(model.Id);
            if (typeEquipment != null)
            {
                typeEquipment.Name = model.Name;
                typeEquipment.Description = model.Description;

                await UpdateAsync(typeEquipment);
                return typeEquipment;
            }

            return null;
        }

        public async Task DeleteTypeEquipmentAsync(string id)
        {
            await DeleteAsync(id);
        }
    }
}
