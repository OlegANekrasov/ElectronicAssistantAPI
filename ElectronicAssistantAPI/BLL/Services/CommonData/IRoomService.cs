using ElectronicAssistantAPI.BLL.Models.CommonData;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;

namespace ElectronicAssistantAPI.BLL.Services.CommonData
{
    public interface IRoomService
    {
        IEnumerable<Room> Get();
        Task<Room> GetByIdAsync(string id);
        Task<Room> AddAsync(AddRoom model);
        Task<Room> UpdateAsync(UpdateRoom model);
        Task DeleteAsync(DelRoom model);
    }
}
