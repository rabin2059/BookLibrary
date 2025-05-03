using BookLibrary.Data;
using BookLibrary.DTOs.Request;
using BookLibrary.DTOs.Response;
using BookLibrary.Model;
using BookLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{
    [Route("api/auth")]
    [ApiController]
   public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly TokenServices _token;

        public AuthController(AuthDbContext context, TokenServices token)
        {
            _context = context;
            _token = token;
        }
    

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO register){
         // Check if username already exists
            if (await _context.Users.AnyAsync(u => u.Username == register.Username))
            {
                return BadRequest("Username is already taken");
            }

            // Check if email already exists
            if (await _context.Users.AnyAsync(u => u.Email == register.Email))
            {
                return BadRequest("Email is already registered");
            }

            // Create new user
            var user = new User
            {
                Username = register.Username,
                Email = register.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(register.Password)
            };

            // Check if this is the first user, if so, make them an Admin
            if (!await _context.Users.AnyAsync())
            {
                user.Role = "Admin";
            }

            // Add user to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // Return user DTO with token
            return Ok(new{
                status = "success",
                message = "User Registered successful",
                statusCode = 200,
                user = new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role
                },
            });
    }
    

     // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<ActionResult<object>> Login(LoginDTO loginDto)
        {
            // Find user by username
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginDto.Username);

            // Check if user exists
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password");
            }

            // Generate JWT token
            var token = _token.GenerateToken(user);

            // Return token and user information
            return Ok(new
            {
                status = "success",
                message = "Login successful",
                statusCode = 200,
                Token = token,
                User = new UserDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role
                }
            });
        }
}
}
