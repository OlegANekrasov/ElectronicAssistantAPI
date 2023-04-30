using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository;
using ElectronicAssistantAPI.DAL.Repository.PersonnelManagement;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace ElectronicAssistantAPI.BLL.Services.PersonnelManagement
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<Position> _positionsRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<UserService> logger,
            IRepository<Position> positionsRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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

            var viewModel = _mapper.Map<UserCompleteViewModel>(user);
            viewModel.FullName = user.GetFullName();
            
            string? roles = "";
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Any())
            {
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
            }
            viewModel.Roles= roles;

            string? position = "";
            if (!string.IsNullOrEmpty(user.PositionId))
            {
                var result = await ((PositionsRepository)_positionsRepository).GetPositionByIdAsync(user.PositionId);
                position = result.Name;
            }
            viewModel.Position = position;

            return viewModel;
        }
    }
}
