using ElectronicAssistantAPI.BLL.Services.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
                if(model == null)
                    return NotFound();

                return new OkObjectResult(model);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpGet");
            }
        }

    }
}
