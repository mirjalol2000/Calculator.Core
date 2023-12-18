using Calculator.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Calculator.Core.Models.Calculations;

namespace Calculator.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Calculation> Calculations { get; set; }

        public async ValueTask<Calculation> InsertCalculationAsync(Calculation calculation) =>
            await InsertAsync(calculation);


        public IQueryable<Calculation> SelectAllCalculations() =>
            SelectAll<Calculation>();


        public async ValueTask<Calculation> SelectCalculationByIdAsync(Guid userId) =>
            await SelectAsync<Calculation>(userId);


        public async ValueTask<Calculation> UpdateCalculationAsync(Calculation calculation) =>
            await UpdateAsync(calculation);


        public async ValueTask<Calculation> DeletedCalculationAsync(Calculation calculation) =>
            await DeleteAsync(calculation);
    }
}
