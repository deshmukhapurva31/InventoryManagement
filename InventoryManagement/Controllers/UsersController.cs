using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Services;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = nameof(GetVisibleUsers))]
        public async Task<ActionResult<Collection<User>>> GetVisibleUsers()
        {

            // TODO: Authorization check. Is the user an admin?

            var users = await _userService.GetUsersAsync();

            return users;
        }

        [Authorize]
        [ProducesResponseType(401)]
        [HttpGet("{userId}", Name = nameof(GetUserById))]
        public Task<IActionResult> GetUserById(Guid userId)
        {
            // TODO is userId the current user's ID?
            // If so, return myself.
            // If not, only Admin roles should be able to view arbitrary users.
            throw new NotImplementedException();
        }

        [HttpPost(Name =nameof(RegisterUser))]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterForm form)
        {
            var (sucess, message) = await _userService.CreateUserAsync(form);
            if (sucess) return Created("todo", null);

            return BadRequest(new ApiError
            {
                Message = "Registration Failed",
                Details = message
            });
        }
    }
}
