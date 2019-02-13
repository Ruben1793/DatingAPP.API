using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPP.API.Data;
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

        public async Task<IActionResult> Register(string username, string password) {
            //validate request

            username = username.ToLower();
            if (await _repo.UserExists(username)) {
                return BadRequest("User already exists");
            }
            var userToCreate = new User
            {
                Username = username,
            };
            var createdUser = await _repo.Register(userToCreate, password);
            return StatusCode(201);
        }
        
    }
}