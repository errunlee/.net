using Calculator.Calculations.Business;
using Calculator.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace learning_by_arun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController
        : ControllerBase
    {
        private readonly ILeads _leads;

        public LeadsController(ILeads lead) {
            _leads = lead;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leads =await _leads.GetLeads();
            return Ok(leads);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ICreateLead payload)
        {
            var res=await _leads.Create(payload);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
           var res=await _leads.Delete(id);
            return Ok(res);
        }

    }
}
