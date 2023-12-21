using Calculator.Core.Models.Users;
using Calculator.Core.Services.Foundations.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        [HttpGet("GetById")]
        public async ValueTask<ActionResult<User>> GetUserById(Guid userId)
        {
            return await this.userService.RetrieveUserByIdAsync(userId);
        }

        [HttpGet]
        public ActionResult<IQueryable<User>> GetAllUsers()
        {
            var users = this.userService.RetrieveAllUsers();

            return Ok(users);
        }

        [HttpPut]
        public async ValueTask<ActionResult<User>> PutUserAsync(User user)
        {
            return await this.userService.ModifyUserAsync(user);
        }

        [HttpDelete]
        public async ValueTask<ActionResult<User>> DeletedUserAsync(Guid userId)
        {
            return await this.userService.RemoveUserAsync(userId);
        }
    }
}
