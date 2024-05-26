using Microsoft.AspNetCore.Mvc;
using Web_App.Interfaces;
using Web_App.Models;
using Web_App.RequestModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
            
        }
        
        // POST api/<AuthController>
        [HttpPost]
        public JWTTokenResponse Login([FromBody] LoginRequest loginRequest)
        {
            var res = _authServices.Login(loginRequest);
            return res;
        }

        // PUT api/<AuthController>/5
        [HttpPost("AddUser")]
        public Users AddUser([FromBody] Users value)
        {
            var user = _authServices.AddUser(value);
            return user;
        }

    }
}
