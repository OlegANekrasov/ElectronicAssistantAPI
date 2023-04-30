using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAsync();
        Task<UserCompleteViewModel> GetByIdAsync(string id);
        //Task<User> AddAsync(AddUser model);
        //Task<User> UpdateAsync(UpdateUser model);
        //Task DeleteAsync(DelUser model);
    }
}
