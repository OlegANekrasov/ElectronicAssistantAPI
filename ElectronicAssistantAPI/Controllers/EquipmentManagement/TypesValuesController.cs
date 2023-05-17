using ElectronicAssistantAPI.BLL.ViewModels.EquipmentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicAssistantAPI.Controllers.EquipmentManagement
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesValuesController : ControllerBase
    {
        [HttpGet(Name = "GetTypesValues")]
        public IActionResult Get()
        {
            var typesValuesViewModel = new TypesValuesViewModel();
            return new OkObjectResult(typesValuesViewModel);
        }
    }
}
