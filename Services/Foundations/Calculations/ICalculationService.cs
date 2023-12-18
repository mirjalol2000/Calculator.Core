using Calculator.Core.Models.Calculations;
using Calculator.Core.Models.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Foundations.Calculations
{
    public interface ICalculationService
    {
        ValueTask<Calculation> AddCalculationAsync(Calculation calculation);
        ValueTask<Calculation> RetrieveCalculationByIdAsync(Guid calculationId);
        IQueryable<Calculation> RetrieveAllCalculations();
        ValueTask<Calculation> ModifyCalculationAsync(Calculation calculation);
        ValueTask<Calculation> RemoveCalculationAsync(Guid calculationId);
    }
}
