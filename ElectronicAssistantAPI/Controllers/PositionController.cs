using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly ILogger<PositionController> _logger;

        public PositionController(ILogger<PositionController> logger)
        {
            _logger = logger;
        }

        /*
        [HttpGet(Name = "GetPositions")]
        public IEnumerable<Position> Get()
        {
            return null;
        }
        */

        [HttpGet(Name = "GetPositions")]
        public IActionResult Get()
        {
            return Ok("You're Authorized");
        }
    }
}