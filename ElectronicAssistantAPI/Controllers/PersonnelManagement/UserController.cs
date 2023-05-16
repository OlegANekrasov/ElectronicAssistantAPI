using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.Services.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers.PersonnelManagement
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<List<UserViewModel>>> Get()
        {
            var users = await _userService.GetAsync();
            return new OkObjectResult(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserCompleteViewModel>> Get(string id)
        {
            try
            {
                var model = await _userService.GetByIdAsync(id);
                if (model == null)
                    return NotFound();

                return new OkObjectResult(model);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpGet");
            }
        }

        [HttpPatch(Name = "Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel viewModel)
        {
            var model = _mapper.Map<UpdateUser>(viewModel);
            var result = await _userService.UpdateAsync(model);
            if (result == null)
            {
                return BadRequest($"Ошибка обновления данных пользователя '{model.Email}'.");
            }

            return Ok(result);
        }

        [HttpPatch(Name = "UpdateRoles")]
        public async Task<IActionResult> UpdateRoles([FromBody] UpdateUserRoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<UpdateUserRole>(viewModel);
                var result = await _userService.UpdateRoleAsync(model);
                if (result == null)
                {
                    return BadRequest("Не удалось обновить роли пользователя.");
                }

                return Ok(result);
            }

            return BadRequest("Ошибка при изменении пароля пользователя.");
        }

        [HttpPatch(Name = "UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<UpdateUserPassword>(viewModel);
                var result = await _userService.UpdatePasswordAsync(model);
                if (result == null)
                {
                    return BadRequest("Ошибка при изменении пароля пользователя.");
                }

                return Ok(result);
            }

            return BadRequest("Ошибка при изменении пароля пользователя.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCompleteViewModel>> Delete(string id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);
                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpDelete");
            }
        }

    }
}
