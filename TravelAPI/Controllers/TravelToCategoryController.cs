using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelToCategoryController(ITravelToCategoryService travelToCategoryService) : ControllerBase
    {
        private readonly ITravelToCategoryService _travelToCategoryService = travelToCategoryService;
        [HttpPost("Add")]
        public IActionResult Add(int travelId, int categoryId)
        {
            var result = _travelToCategoryService.Add(travelId, categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);    
        }
    }
}
