using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Extentions;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.DAL.Repository.PersonnelManagement;
using Microsoft.AspNetCore.Identity;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRepository<Position> _positionsRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            ILogger<UserService> logger,
            IRepository<Position> positionsRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _positionsRepository = positionsRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> GetAsync()
        {
            var users = _userManager.Users.ToList();
            var userList = new List<UserViewModel>();
            foreach (var user in users)
            {
                string Id = user.Id;
                string? fullName = user.GetFullName();
                string? email = user.Email;
                byte[]? image = user.Image;
                
                string? position = "";
                if (!string.IsNullOrEmpty(user.PositionId))
                {
                    var result = await ((PositionsRepository)_positionsRepository).GetPositionByIdAsync(user.PositionId);
                    position = result.Name;
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Any())
                {
                    string? roles = "";
                    bool first = true;
                    foreach (var role in userRoles.OrderBy(o => o))
                    {
                        if (first)
                        {
                            roles = role;
                            first = false;
                        }
                        else
                        {
                            roles += (", " + role);
                        }
                    }

                    userList.Add(new UserViewModel(Id, fullName, email, roles, image, position));
                }
            }

            return userList;
        }

        public async Task<UserCompleteViewModel> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogError($"Не найден пользователь с ID '{id}'.");
                return null;
            }

            return await SetUserCompleteViewModel(user);
        }

        public async Task<UserCompleteViewModel> UpdateAsync(UpdateUser model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                _logger.LogError($"Не найден пользователь с ID '{model.Id}'.");
                return null;
            }

            user.Convert(model);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                _logger.LogError($"Ошибка обновления данных пользователя с ID '{user.Id}'.");
                return null;
            }

            return await SetUserCompleteViewModel(user);
        }

        public async Task<UserCompleteViewModel> UpdatePasswordAsync(UpdateUserPassword model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                _logger.LogError($"Не найден пользователь с ID '{model.Id}'.");
                return null;
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    _logger.LogError(error.Description);
                }

                return null;
            }

            await _signInManager.RefreshSignInAsync(user);
            return await SetUserCompleteViewModel(user);
        }

        public async Task<UserCompleteViewModel> UpdateRoleAsync(UpdateUserRole model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                _logger.LogError($"Не найден пользователь с ID '{model.Id}'.");
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var item in model.Roles)
            {
                if (item.IsRoleAssigned && userRoles.FirstOrDefault(o => o == item.Name) == null)
                {
                    var result = await _userManager.AddToRoleAsync(user, item.Name);
                    if (!result.Succeeded)
                    {
                        _logger.LogError($"Ошибка при добавлении роли '{item.Name}' пользователю '{user.Email}'.");
                        return null;
                    }
                }
                else if(!item.IsRoleAssigned && userRoles.FirstOrDefault(o => o == item.Name) != null)
                {
                    var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!result.Succeeded)
                    {
                        _logger.LogError($"Ошибка при удалении роли '{item.Name}' пользователю '{user.Email}'.");
                        return null;
                    }
                }
            }

            return await SetUserCompleteViewModel(user);
        }

        public async Task<string> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return $"Пользователь с ID '{id}' успешно удален.";
                }
                else
                {
                    return $"Ошибка удаления пользователя с ID '{id}'.";
                }
            }
            else
            {
                return $"Не найден пользователь с ID '{id}'.";
            }
        }

        public async Task<UserCompleteViewModel> SetUserCompleteViewModel(User user)
        {
            var viewModel = _mapper.Map<UserCompleteViewModel>(user);
            viewModel.FullName = user.GetFullName();

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = new List<UserRole>();

            var allRoles = _roleManager.Roles;
            foreach (var role in allRoles.OrderBy(o => o))
            {
                UserRole userRole = new UserRole() { Name = role.Name };
                if (userRoles.FirstOrDefault(o => o == role.Name) != null)
                {
                    userRole.IsRoleAssigned = true;
                }

                roles.Add(userRole);
            }

            viewModel.Roles = roles;

            if (!string.IsNullOrEmpty(user.PositionId))
            {
                viewModel.Position = await ((PositionsRepository)_positionsRepository).GetPositionByIdAsync(user.PositionId);
            }

            return viewModel;
        }
    }
}
