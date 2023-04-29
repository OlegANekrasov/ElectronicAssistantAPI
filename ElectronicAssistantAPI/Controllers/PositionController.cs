using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.Services.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ElectronicAssistantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var positions = _positionService.Get();
            return new OkObjectResult(positions);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            try
            {
                var position = _positionService.GetByIdAsync(id);
                return new OkObjectResult(position);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpGet");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Position>> Post([FromBody] AddPosition model)
        {
            try
            {
                var position = await _positionService.AddAsync(model);
                return CreatedAtAction("Get", new { id = position.Id }, position);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPost");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Position>> Put([FromBody] UpdatePosition model)
        {
            try
            {
                var position = await _positionService.UpdateAsync(model);
                return new OkObjectResult(position);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPut");
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DelPosition model)
        {
            try
            {
                _positionService.DeleteAsync(model);
                return new OkResult();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpDelete");
            }
        }
    }
}