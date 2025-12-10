using Calculator.Calculations.Business;
using Calculator.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace learning_by_arun.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHome _home;
        public HomeController(IHome home)
        {
            _home = home;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _home.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _home.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HomePayload payload)
        {
            await _home.CreateAsync(payload);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] HomePayload payload)
        {
            var updated = await _home.UpdateAsync(id, payload);
            if (updated == 0) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _home.DeleteAsync(id);
            if (deleted == 0) return NotFound();
            return Ok();
        }
    }
}
