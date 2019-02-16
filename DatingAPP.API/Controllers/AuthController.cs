using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPP.API.Data;
using DatingAPP.API.Dtos;
using DatingAPP.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) {
            //validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDto.Username)) {
                return BadRequest("User already exists");
            }
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
            };
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }
        
    }
}