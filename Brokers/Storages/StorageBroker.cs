using Calculator.Core.Models.Users;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
        public async ValueTask<User> SelectUserByIdAsync(Guid userId)=>
            await this.Users.FirstOrDefaultAsync(u => u.Id == userId);

        public IQueryable<User> SelectAllUsers()
        {
            return this.Users.AsQueryable();
        }

        public async ValueTask<User> UpdateUserAsync(User updatedUser)
        {
            var user = this.Users.Find(updatedUser.Id);

            this.Entry(user).CurrentValues.SetValues(updatedUser);

            await this.SaveChangesAsync();
            return updatedUser;
        }
        public async ValueTask<User> DeleteUserAsync(User user)
        {
            this.Remove(user);
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
