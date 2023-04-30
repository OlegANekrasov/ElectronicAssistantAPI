using AutoMapper;
using ElectronicAssistantAPI.BLL.Models.PersonnelManagement;
using ElectronicAssistantAPI.BLL.Services.PersonnelManagement;
using ElectronicAssistantAPI.BLL.ViewModels.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Models.PersonnelManagement;
using ElectronicAssistantAPI.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using System;
using System.Transactions;

namespace ElectronicAssistantAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPositions")]
        public IActionResult Get()
        {
            var positions = _positionService.Get();
            return new OkObjectResult(positions);
        }

        [HttpGet("{id}", Name = "GetPositionById")]
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
        public async Task<ActionResult<Position>> Post([FromBody] AddPositionViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<AddPosition>(viewModel);
                var position = await _positionService.AddAsync(model);
                return CreatedAtAction("Get", new { id = position.Id }, position);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPost");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Position>> Put([FromBody] UpdatePositionViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<UpdatePosition>(viewModel);
                var position = await _positionService.UpdateAsync(model);
                return new OkObjectResult(position);
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpPut");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DelPositionViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<DelPosition>(viewModel);
                await _positionService.DeleteAsync(model);
                return new OkResult();
            }
            catch (Exception)
            {
                return BadRequest("Ошибка при выполнении запроса HttpDelete");
            }
        }
    }
}