using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recommended.Data;
using Recommended.Entities;
using System.Security.Cryptography;
using System.Text;
using WebApplication2.API.Entities.DTOs;
using WebApplication2.API.Entities.Users;

namespace WebApplication2.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(UserContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO user)
        {
            if(await UserExists(user.Username))
            {
                return BadRequest("Username is taken!");
            }

            using var hmac = new HMACSHA512();

            var newUser = new DbUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username.ToLower(),
                PhoneNumber = user.PhoneNumber,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();

            return new UserDTO()
            {
                UserName = user.Username,
                Token = _tokenService.CreateToken(newUser)
            };
        }

        [HttpPost("auth")]
        public async Task<ActionResult<UserDTO>> Login(AuthDTO loginData)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == loginData.Credential);

            if(user == null)
            {
                return Unauthorized("Your credential doesn't exists!");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginData.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Password is not valid!");
                }
            }

            return new UserDTO()
            {
                UserName = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }


        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username.ToLower());
        }

    }
}
