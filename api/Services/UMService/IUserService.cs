using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.UMS;

namespace api.Services.UMService
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUserByUsername(string username);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> UpdateUser(UpdateUserDto updateUser);
        Task<IEnumerable<UserDto>> DeleteUser(int id);
    }
}