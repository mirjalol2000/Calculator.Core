using Calculator.Core.Models.Calculations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Calculation> InsertCalculationAsync(Calculation calculation);
        IQueryable<Calculation> SelectAllCalculations();
        ValueTask<Calculation> SelectCalculationByIdAsync(Guid userId);
        ValueTask<Calculation> UpdateCalculationAsync(Calculation calculation);
        ValueTask<Calculation> DeletedCalculationAsync(Calculation calculation);
    }
}
