using Calculator.Core.Models.Calculations;
using Calculator.Core.Models.Users;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Processings.Calculations
{
    public interface ICalculationProcessingService
    {
        ValueTask<string> Calculate(Calculation calculation, User user);
    }
}
