using api.Models.UserManagment;

namespace api.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}