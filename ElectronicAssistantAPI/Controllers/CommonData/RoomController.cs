using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.CommonData;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.Services.CommonData;
using ElectronicAssistantAPI.BLL.Services.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.CommonData;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers.CommonData
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRooms")]
        public IActionResult Get()
        {
            var rooms = _roomService.Get();
            return new OkObjectResult(rooms);
        }

        [HttpGet("{id}", Name = "GetRoomById")]
        public IActionResult Get(string id)
        {
            try
            {
                var room = _roomService.GetByIdAsync(id);
                return new OkObjectResult(room);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpGet");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Room>> Post([FromBody] AddRoomViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<AddRoom>(viewModel);
                var room = await _roomService.AddAsync(model);
                return CreatedAtAction("Get", new { id = room.Id }, room);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPost");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Room>> Put([FromBody] UpdateRoomViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<UpdateRoom>(viewModel);
                var room = await _roomService.UpdateAsync(model);
                return new OkObjectResult(room);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPut");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DelRoomViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<DelRoom>(viewModel);
                await _roomService.DeleteAsync(model);
                return new OkResult();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpDelete");
            }
        }
    }
}
