using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using System.Xml;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public interface IPositionService
    {
        IEnumerable<Position> Get();
        Task<Position> GetByIdAsync(string id);
        Task<Position> AddAsync(AddPosition model);
        Task<Position> UpdateAsync(UpdatePosition model);
        Task DeleteAsync(DelPosition model);
    }
}
