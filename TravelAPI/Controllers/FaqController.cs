using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController(IFaqService faqService) : ControllerBase
    {
        private readonly IFaqService _faqService = faqService;
        [HttpPost]
        public IActionResult Post(Faq faq)
        {
            var result = _faqService.Add(faq);
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
            var result = _faqService.GetAll();
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
            var result = _faqService.Get(id);
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
            var result = _faqService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
        [HttpPut]
        public IActionResult Update(Faq faq, int id)
        {
            var result = _faqService.Update(id, faq);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
