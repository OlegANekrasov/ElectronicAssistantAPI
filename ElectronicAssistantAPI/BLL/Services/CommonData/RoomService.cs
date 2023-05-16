using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.Services.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Repository.CommonData;
using ElectronicAssistantAPI.BLL.Models.CommonData;

namespace ElectronicAssistantAPI.BLL.Services.CommonData
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomsRepository;
        private readonly ILogger<RoomService> _logger;

        public RoomService(IRepository<Room> roomsRepository, ILogger<RoomService> logger)
        {
            _roomsRepository = roomsRepository;
            _logger = logger;
        }

        public IEnumerable<Room> Get()
        {
            return ((RoomsRepository)_roomsRepository).GetRooms();
        }

        public async Task<Room> GetByIdAsync(string id)
        {
            return await ((RoomsRepository)_roomsRepository).GetRoomByIdAsync(id);
        }

        public async Task<Room> AddAsync(AddRoom model)
        {
            return await ((RoomsRepository)_roomsRepository).AddRoomAsync(model);
        }

        public async Task<Room> UpdateAsync(UpdateRoom model)
        {
            return await ((RoomsRepository)_roomsRepository).UpdateRoomAsync(model);
        }

        public async Task DeleteAsync(DelRoom model)
        {
            await ((RoomsRepository)_roomsRepository).DeleteRoomAsync(model.Id);
        }
    }
}
