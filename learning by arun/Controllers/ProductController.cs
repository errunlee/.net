using Calculator.Calculations.Business;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace learning_by_arun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _prod;
        public ProductController(IProduct product)
        {
            _prod = product;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _prod.GetAll());
        }

      

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDto payload)
        {
            return Ok(await _prod.Create(payload));
        }

    }
}
