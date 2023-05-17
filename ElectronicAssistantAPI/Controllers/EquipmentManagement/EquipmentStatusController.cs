using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.CommonData;
using ElectronicAssistantAPI.BLL.Models.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.BLL.Services.CommonData;
using ElectronicAssistantAPI.BLL.Services.EquipmentManagement;
using ElectronicAssistantAPI.BLL.ViewModels.CommonData;
using ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement.EquipmentStatus;
using ElectronicAssistantAPI.DAL.Models.CommonData;
using ElectronicAssistantAPI.DAL.Models.EquipmentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers.EquipmentManagement
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentStatusController : ControllerBase
    {
        private readonly IEquipmentStatusService _equipmentStatusService;
        private readonly IMapper _mapper;

        public EquipmentStatusController(IEquipmentStatusService equipmentStatusService, IMapper mapper)
        {
            _equipmentStatusService = equipmentStatusService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetEquipmentStatuses")]
        public IActionResult Get()
        {
            var equipmentStatuses = _equipmentStatusService.Get();
            return new OkObjectResult(equipmentStatuses);
        }

        [HttpGet("{id}", Name = "GetEquipmentStatusById")]
        public IActionResult Get(string id)
        {
            try
            {
                var equipmentStatus = _equipmentStatusService.GetByIdAsync(id);
                return new OkObjectResult(equipmentStatus);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpGet");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentStatus>> Post([FromBody] AddEquipmentStatusViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<AddEquipmentStatus>(viewModel);
                var equipmentStatus = await _equipmentStatusService.AddAsync(model);
                return CreatedAtAction("Get", new { id = equipmentStatus.Id }, equipmentStatus);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPost");
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentStatus>> Put([FromBody] UpdateEquipmentStatusViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<UpdateEquipmentStatus>(viewModel);
                var equipmentStatus = await _equipmentStatusService.UpdateAsync(model);
                return new OkObjectResult(equipmentStatus);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPut");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DelEquipmentStatusViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<DelEquipmentStatus>(viewModel);
                await _equipmentStatusService.DeleteAsync(model);
                return new OkResult();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpDelete");
            }
        }
    }
}
