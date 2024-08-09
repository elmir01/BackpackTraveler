using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutMeService _aboutMeService;
        public AboutController(IAboutMeService aboutMeService)
        {
            _aboutMeService = aboutMeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _aboutMeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }else 
                return BadRequest(result);
        }
        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            var result = _aboutMeService.Get(id);
            if (result.Success) 
            {
                return Ok(result);
            }
            else 
                return BadRequest(result);
        }

        [HttpPost]
        public  IActionResult Post(AboutMe aboutMe)
        {
            var result = _aboutMeService.Add(aboutMe);
            if (result.Success)
            {
                return Ok(result);
            }else 
                return BadRequest(result);  
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _aboutMeService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }else return BadRequest(result);    
        }

        [HttpPut("{id:int:min(1)}")]
        public IActionResult Update(int id, AboutMe aboutMe)
        {
            var result = _aboutMeService.Update(id,aboutMe);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
    }
}
    }
