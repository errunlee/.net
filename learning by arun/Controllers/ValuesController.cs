using Calculator.Calculations.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace learning_by_arun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICalculation _cal;
        public ValuesController(ICalculation calculation)
        {
            _cal = calculation; 
        }



        [HttpPost]
        public object Caclulation(int value)
        {
            var Response=_cal.Calculation(value);
            return Response;
        }
    }
}
