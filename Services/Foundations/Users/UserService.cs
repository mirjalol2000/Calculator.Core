﻿using Calculator.Core.Brokers.Storages;
using Calculator.Core.Models.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<User> AddUserAsync(User user) =>
            await this.storageBroker.InsertUserAsync(user);

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.storageBroker.UpdateUserAsync(user);


        public async ValueTask<User> RemoveUserAsync(Guid userId)
        {
            var user = await this.storageBroker.SelectUserByIdAsync(userId);

            return await this.storageBroker.DeleteUserAsync(user);
        }


        public IQueryable<User> ReterieveAllUsers() =>
            this.storageBroker.SelectAllUsers();
        

        public async ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
            await this.storageBroker.SelectUserByIdAsync(userId);
        
    }
}
