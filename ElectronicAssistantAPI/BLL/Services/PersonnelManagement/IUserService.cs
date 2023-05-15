using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAsync();
        Task<UserCompleteViewModel> GetByIdAsync(string id);
        Task<UserCompleteViewModel> UpdateAsync(UpdateUser model);
        Task<UserCompleteViewModel> UpdatePasswordAsync(UpdateUserPassword model);
        Task<UserCompleteViewModel> UpdateRoleAsync(UpdateUserRole model);
        Task<string> DeleteAsync(string id);
    }
}
