using ASPTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerServices _beerServices;

        public BeerController(IBeerServices beerServices)
        {
            _beerServices = beerServices;
        }
        
        [HttpGet]
        public IActionResult Get() => Ok(_beerServices.Get());

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            var beer = _beerServices.Get(Id);
            if (beer == null) return NotFound();

            return Ok(beer);
        }
    }
}
