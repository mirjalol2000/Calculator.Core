using Calculator.Core.Models.Users;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Calculator.Core.Brokers.Storages
{
    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        DbSet<User> Users { get; set; }

        public StorageBroker() =>
            this.Database.EnsureCreated();

        public async ValueTask<User> InsertUserAsync(User user)
        {
            await this.Users.AddAsync(user);
            await this.SaveChangesAsync();

            return user;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source = CalculatorCore.db";
            optionsBuilder.UseSqlite(connectionString); 
        }
    }
}
