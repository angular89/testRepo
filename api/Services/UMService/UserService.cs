using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.UMS;
using api.Helpers;
using api.Models.UserManagment;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Services.UMService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<IEnumerable<UserDto>> GetUserByUsername(string username)
        {
            return await _context.Users
            .Where(x => x.UserName.ToLower().Contains(username.ToLower()))
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _context.Employees
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<UserDto> UpdateUser(UpdateUserDto updateUser)
        {
            string Password;
            var newPassword = new PasswordGenerator();
            Password = newPassword.GeneratePassword(true, true, true, 5);
            
            using var hmac = new HMACSHA512();
            User user = await _context.Users
            .FirstOrDefaultAsync(c => c.Id == updateUser.Id);
    
            user.UserName = updateUser.Username;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(updateUser.Password));
            user.PasswordSalt = hmac.Key;
            user.Mobile = updateUser.Mobile;
            user.Actor = updateUser.Actor;
            user.Status = updateUser.Status;
            //send sms to the user with new password....

            await _context.SaveChangesAsync();


            return await _context.Employees
            .Where(x => x.Id == updateUser.Id)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<UserDto>> DeleteUser(int id)
        {
            User user = await _context.Users
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return await _context.Users
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}