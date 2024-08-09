using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        [HttpPost]
        public IActionResult Post(Travel travel)
        {
            var result = _travelService.Add(travel);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);    
            }
        }

        [HttpGet]   
        public IActionResult GetAll()
        {
            var result = _travelService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);    
            }
        }

        [HttpGet("get{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            var result = _travelService.Get(id);
            if (result.Success)
            {
                return Ok(result);  
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _travelService?.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result); 
        }
        [HttpPut]
        public IActionResult Update(Travel travel, int id)
        {
            var result = _travelService.Update(id, travel);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


    }
}
