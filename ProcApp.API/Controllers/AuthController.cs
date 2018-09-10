using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProcApp.API.Data;
using ProcApp.API.Dtos;
using ProcApp.API.Helpers;
using ProcApp.API.Models;

namespace ProcApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenBuilder _tokenBuilder;
        public AuthController(IAuthRepository repo, ITokenBuilder tokenBuilder)
        {
            _tokenBuilder = tokenBuilder;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var tokenObj = _tokenBuilder.BuildToken(userFromRepo);

            return Ok(tokenObj);
        }
    }
}