using FlightDocsSystem.Models;
using FlightDocsSystem.ViewModels;
using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocsSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(UserDto request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Permission = request.Permission,
                CreatedDate = DateTime.Now
            };
            _userService.CreateUser(user);

            return Ok(request);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _userService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult UpsertUser(UserVM request)
        {
            var user = new User
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Permission = request.Permission
            };
            _userService.UpsertUser(user);

            return Ok(_userService.GetUser(request.Id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);

            return Ok();
        }
    }
}
