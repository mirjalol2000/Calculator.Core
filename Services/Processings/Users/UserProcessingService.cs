using Calculator.Core.Brokers.Storages;
using Calculator.Core.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;
using Calculator.Core.Services.Foundations.Users;
using Calculator.Core.Models.Users.Exceptions;

namespace Calculator.Core.Services.Processings.Users
{
    public class UserProcessingService : IUserProcessingService
    {
        private readonly IUserService userService;

        public UserProcessingService(IUserService userService)
        {
            this.userService = userService;
        }

        public User RetrieveUserByName(string userName)
        {
            var maybeUser = this.userService.RetrieveAllUsers()
                .FirstOrDefault(u => u.FirstName == userName);
            if(maybeUser is null) 
                throw new UserNotFoundByNameException(userName);
            else
                return maybeUser;
            

        }

        public async ValueTask<User> AddUserAsync(User user) =>
            await this.userService.AddUserAsync(user);

        public async ValueTask<User> ModifyUserAsync(User user) =>
            await this.userService.ModifyUserAsync(user);


        public async ValueTask<User> RemoveUserAsync(Guid userId) =>
             await this.userService.RemoveUserAsync(userId);


        public IQueryable<User> RetrieveAllUsers() =>
            this.userService.RetrieveAllUsers();


        public async ValueTask<User> RetrieveUserByIdAsync(Guid userId) =>
            await this.userService.RetrieveUserByIdAsync(userId);
    }
}
