using ElectronicAssistantAPI.BLL.Models.CommonData;
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

        public async Task<Room> AddRoomAsync(AddRoom model)
        {
            var room = new Room()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Description = model.Description,
            };

            await CreateAsync(room);
            return room;
        }

        public async Task<Room> UpdateRoomAsync(UpdateRoom model)
        {
            var room = await GetByIdAsync(model.Id);
            if (room != null)
            {
                room.Name = model.Name;
                room.Description = model.Description;

                await UpdateAsync(room);
                return room;
            }

            return null;
        }

        public async Task DeleteRoomAsync(string id)
        {
            await DeleteAsync(id);
        }
    }
}
