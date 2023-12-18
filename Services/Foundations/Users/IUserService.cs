using Calculator.Core.Models.Users;
using System.Threading.Tasks;

namespace Calculator.Core.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
    }
}
