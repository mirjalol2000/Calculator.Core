using Calculator.Core.Models.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User>  InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeletedUserAsync(User user);

    }
}
