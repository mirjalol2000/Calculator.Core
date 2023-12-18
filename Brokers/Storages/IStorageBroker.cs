using Calculator.Core.Models.Users;
using System.Threading.Tasks;

namespace Calculator.Core.Brokers.Storages
{
    public interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
    }
}
