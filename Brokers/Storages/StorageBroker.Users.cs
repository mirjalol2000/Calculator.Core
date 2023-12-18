﻿using Calculator.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Calculator.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);


        public IQueryable<User> SelectAllUsers() =>
            SelectAll<User>();
        

        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
            await SelectAsync<User>(userId);
        

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await UpdateAsync(user);


        public async ValueTask<User> DeletedUserAsync(User user) =>
            await DeleteAsync(user);
        
    }
}
