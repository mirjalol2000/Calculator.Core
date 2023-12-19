using Calculator.Core.Models.Users;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Calculator.Core.Services.Processings.Users
{
    public interface IUserProcessingService
    {
        User RetrieveUserByName(string userName);
        ValueTask<User> AddUserAsync(User user);
        ValueTask<User> RetrieveUserByIdAsync(Guid userId);
        IQueryable<User> RetrieveAllUsers();
        ValueTask<User> ModifyUserAsync(User user);
        ValueTask<User> RemoveUserAsync(Guid userId);
    }
}
