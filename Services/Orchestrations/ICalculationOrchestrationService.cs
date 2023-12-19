using Calculator.Core.Models.Calculations;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Orchestrations
{
    public interface ICalculationOrchestrationService
    {
        ValueTask<string> ManageAllFunctions(string userName, Calculation calculation);
        
    }
}
