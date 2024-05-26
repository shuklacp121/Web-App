using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_App.Interfaces;
using Web_App.Models;
using Web_App.RequestModels;
using LoginRequest = Web_App.RequestModels.LoginRequest;

namespace Web_App.Services
{
    public class AuthService : IAuthServices
    {
        private readonly FirstAppContext _firstAppContext;
        private readonly IConfiguration _configuration;
        public AuthService(FirstAppContext firstAppContext, IConfiguration configuration) 
        {
            _firstAppContext = firstAppContext;
            _configuration = configuration;
        }
        public Users AddUser(Users user)
        {
            var addUser = _firstAppContext.Users.Add(user);
            _firstAppContext.SaveChanges();
            return addUser.Entity;
        }

        public JWTTokenResponse Login(LoginRequest loginRequest)
        {
            if (loginRequest.UserName != null && loginRequest.Password != null)
            {
                var user = _firstAppContext.Users.SingleOrDefault(s => s.Email == loginRequest.UserName && s.Password == loginRequest.Password);
                if (user != null)
                {

                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return new JWTTokenResponse
                    {
                        Token = jwtToken
                    };
                    //return jwtToken;
                }
                else
                {
                    throw new Exception("User Not found!");
                }

            }
            else 
            {
                throw new Exception("Credentials are not valid");
            }
        }

       
    }
}
