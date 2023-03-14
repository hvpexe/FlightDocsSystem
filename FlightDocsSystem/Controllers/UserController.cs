using FlightDocsSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Net;
using AutoMapper;
using FlightDocsSystem.Helpers;

namespace FlightDocsSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            if (users == null) return NotFound();
            var userVMs = users.Select(x => _mapper.Map<UserVM>(x));
            return Ok(userVMs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /*
         *  API tạo mới 1 tài khoản
         *  Email đúng theo định dạng đuôi "@vietjetair.com", không trùng
         *  Tên không trống
         *  Mật khẩu (8-40 kí tự, có chữ in hoa, in thường, số), cần mã hóa (hiện tại chưa có)
         *  
         */
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel request)
        {

            //check email, password, phone format
            var checkEmailResult = RegexHelper.CheckEmail(request.Email);
            if (!checkEmailResult.IsMatched) 
            {
                return BadRequest(checkEmailResult.Message);
            }

            var checkPasswordResult = RegexHelper.CheckPassword(request.Password);
            if (!checkPasswordResult.IsMatched)
            {
                return BadRequest(checkPasswordResult.Message);
            }

            var checkPhoneNumberResult = RegexHelper.CheckPassword(request.Phone);
            if (!checkPhoneNumberResult.IsMatched)
            {
                return BadRequest(checkPhoneNumberResult.Message);
            }

            if (request.Name.IsNullOrEmpty())
            {
                return BadRequest("Name must not be empty");
            }

            if (await _userRepository.IsEmailExistAsync(request.Email))
            {
                return BadRequest("Email has been duplicated");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone,
                Permission = request.Permission, // permission truyền vào dưới dạng string
                CreatedDate = DateTime.Now
            };

            try
            {
                await _userRepository.CreateUserAsync(user);
                return Ok(request);
            }
            catch
            {
                return BadRequest("Error when register new user.");
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpsertUser(UserVM request)
        {
            //check email, phone format
            var checkEmailResult = RegexHelper.CheckEmail(request.Email);
            if (!checkEmailResult.IsMatched)
            {
                return BadRequest(checkEmailResult.Message);
            }

            var checkPhoneNumberResult = RegexHelper.CheckPhoneNumber(request.Phone);
            if (!checkPhoneNumberResult.IsMatched)
            {
                return BadRequest(checkPhoneNumberResult.Message);
            }

            if (request.Name.IsNullOrEmpty())
            {
                return BadRequest("Name must not empty");
            }

            if (await _userRepository.IsEmailExistAsync(request.Email))
            {
                return BadRequest("Email has been duplicated");
            }

            var user = new User
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Permission = request.Permission
            };
            await _userRepository.UpsertUserAsync(user);

            return Ok(_userRepository.GetUserByIdAsync(request.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUserAsync(id);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Validate(LoginModel model)
        {
            var user = await _userRepository.LoginAsync(model);
            if (user == null) //khong dung
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            //cấp token
            //var token = await GenerateToken(user);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                //Data = token
            }); 
        }
    }
}
