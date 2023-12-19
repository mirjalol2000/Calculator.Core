using Calculator.Core.Models.Calculations;
using Calculator.Core.Services.Orchestrations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Calculator.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : Controller
    {
        private readonly ICalculationOrchestrationService calculationOrchestrationService;

        public CalculationController(ICalculationOrchestrationService calculationOrchestrationService)
        {
            this.calculationOrchestrationService = calculationOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<string>> GetFeedback(
            string userName, Calculation calculation)
        {
            var feedback = await this.calculationOrchestrationService
                .ManageAllFunctions(userName, calculation);

            return Ok(feedback);
        }
    }
}
