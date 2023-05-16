using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.EF;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;

namespace ElectronicAssistantAPI.DAL.Repository.CommonData
{
    public class RoomsRepository : Repository<Room>
    {
        public RoomsRepository(ApplicationDbContext db) : base(db)
        {

        }

        public IEnumerable<Room> GetRooms()
        {
            return base.Get();
        }

        public async Task<Room> GetRoomByIdAsync(string id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<Room> AddRoomAsync(AddPosition model)
        {
            var position = new Room()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
            };

            await CreateAsync(position);
            return position;
        }

        public async Task<Room> UpdateRoomAsync(UpdatePosition model)
        {
            var position = await GetByIdAsync(model.Id);
            if (position != null)
            {
                position.Name = model.Name;
                position.Description = model.Description;

                await UpdateAsync(position);
                return position;
            }

            return null;
        }

        public async Task DeleteRoomAsync(string id)
        {
            await DeleteAsync(id);
        }
    }
}
