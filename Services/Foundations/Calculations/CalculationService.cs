using Calculator.Core.Brokers.Storages;
using Calculator.Core.Models.Calculations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Foundations.Calculations
{
    public class CalculationService : ICalculationService
    {
        private readonly IStorageBroker storageBroker;

        public CalculationService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Calculation> AddCalculationAsync(Calculation calculation) =>
            await this.storageBroker.InsertCalculationAsync(calculation);
        

        public async ValueTask<Calculation> ModifyCalculationAsync(Calculation calculation) =>
            await this.storageBroker.UpdateCalculationAsync(calculation);

        public IQueryable<Calculation> RetrieveAllCalculations() =>
            this.storageBroker.SelectAllCalculations();

        public async ValueTask<Calculation> RemoveCalculationAsync(Guid calculationId)
        {
            var calculation = await this.storageBroker.SelectCalculationByIdAsync(calculationId);
            
            return await this.storageBroker.DeletedCalculationAsync(calculation);
        }
        
        public async ValueTask<Calculation> RetrieveCalculationByIdAsync(Guid calculationId) =>
            await this.storageBroker.SelectCalculationByIdAsync(calculationId);
        
    }
}
