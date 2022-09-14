using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerPlant.Application.Interface;
using PowerPlant.Entities;

namespace PlantPower.WepApi.Controllers
{
    
    [ApiController]
    [Route("api/PowerPlant")]
    public class PowerPlantController : ControllerBase
    {
        public IPowerPlantService PowerPlantService { get; }

        public PowerPlantController(IPowerPlantService powerPlantService)
        {
            PowerPlantService = powerPlantService;
        }


        [HttpPost(Name = "PowerPlant")]
        public ActionResult<List<PowerProduced>> GetPower(PayLoad playLoad)
        {
            try
            {
                var result = PowerPlantService.GetPower(playLoad);
                return result != null ? Ok(result) : BadRequest("can not reach required load, Check the data you entered");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
    }
}
