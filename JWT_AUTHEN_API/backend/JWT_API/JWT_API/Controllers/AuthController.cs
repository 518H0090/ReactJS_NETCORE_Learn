using JWT_API.Data;
using JWT_API.Dtos;
using JWT_API.Helpers;
using JWT_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JWTServices _jwtService;

        public AuthController(IUserRepository repository, JWTServices jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                UserName = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };

            return Created("success",_repository.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if(user == null)
            {
                return BadRequest("Invalid Credentials");
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest("Invalid Creadentials");
            }

            var jwtString = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt",jwtString,new CookieOptions
            {
                    HttpOnly = true,
            });

            return Ok(new
            {
                message = "success",
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            } catch (Exception ex)
            {
                return Unauthorized();
            }
         
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "success",
            });
        }
    }
}
