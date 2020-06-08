using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M151API.Models;
using M151API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using M151API.Models;

namespace M151API.Controllers
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

        [HttpPost("login")]
        public User Login([FromBody]AuthenticateRequest authenticateRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Modelstate Invalid");
            }
          return _userService.Authenticate(authenticateRequest.Username, authenticateRequest.Password);
        }
    }
}