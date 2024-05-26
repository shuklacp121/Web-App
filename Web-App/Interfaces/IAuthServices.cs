using Web_App.Models;
using Web_App.RequestModels;
using LoginRequest = Web_App.RequestModels.LoginRequest;

namespace Web_App.Interfaces
{
    public interface IAuthServices
    {
        Users AddUser(Users user);
        JWTTokenResponse Login(LoginRequest loginRequest);
    }
}
