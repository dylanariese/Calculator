using Calculator.Models.Interfaces;
using Calculator.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly IRunner runner;

        public CalculationsController(IRunner runner)
        {
            this.runner = runner;
        }

        // POST api/calculations
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalculationCollection values)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await runner.RunAsync(values);

            return Ok(result);
        }
    }
}
