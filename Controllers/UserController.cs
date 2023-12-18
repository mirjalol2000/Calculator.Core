using Calculator.Core.Models.Users;
using Calculator.Core.Services.Foundations.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Calculator.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> PostUserAsync(User user)
        {
            return await userService.AddUserAsync(user);
        }
    }
}
