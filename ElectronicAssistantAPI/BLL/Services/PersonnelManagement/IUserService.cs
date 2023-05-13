using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAsync();
        Task<UserCompleteViewModel> GetByIdAsync(string id);
        //Task<User> UpdateAsync(UpdateUser model);
        Task<string> DeleteAsync(string id);
    }
}
