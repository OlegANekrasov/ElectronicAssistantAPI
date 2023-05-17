using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.TypeEquipment;
using ElectronicAssistantAPI.BLL.Services.EquipmentManagement;
using ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.TypeEquipment;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers.EquipmentManagement
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TypeEquipmentController : ControllerBase
    {
        private readonly ITypeEquipmentService _typeEquipmentService;
        private readonly IMapper _mapper;

        public TypeEquipmentController(ITypeEquipmentService typeEquipmentService, IMapper mapper)
        {
            _typeEquipmentService = typeEquipmentService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTypeEquipment")]
        public IActionResult Get()
        {
            var typesEquipment = _typeEquipmentService.Get();
            return new OkObjectResult(typesEquipment);
        }

        [HttpGet("{id}", Name = "GetTypeEquipmentById")]
        public IActionResult Get(string id)
        {
            try
            {
                var typeEquipment = _typeEquipmentService.GetByIdAsync(id);
                return new OkObjectResult(typeEquipment);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpGet");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TypeEquipment>> Post([FromBody] AddTypeEquipmentViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<AddTypeEquipment>(viewModel);
                var typeEquipment = await _typeEquipmentService.AddAsync(model);
                return CreatedAtAction("Get", new { id = typeEquipment.Id }, typeEquipment);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPost");
            }
        }

        [HttpPut]
        public async Task<ActionResult<TypeEquipment>> Put([FromBody] UpdateTypeEquipmentViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<UpdateTypeEquipment>(viewModel);
                var typeEquipment = await _typeEquipmentService.UpdateAsync(model);
                return new OkObjectResult(typeEquipment);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPut");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DelTypeEquipmentViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<DelTypeEquipment>(viewModel);
                await _typeEquipmentService.DeleteAsync(model);
                return new OkResult();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpDelete");
            }
        }
    }
}
