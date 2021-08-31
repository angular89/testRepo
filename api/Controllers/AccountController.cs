using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.HMS;
using api.DTOs.UMS;
using api.Helpers;
using api.Models.HumanResource;
using api.Models.UserManagment;
using api.Services;
using api.Services.HRService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        public AccountController(DataContext context, ITokenService tokenService, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("registerEmployee")]
        public async Task<ActionResult<EmployeeDto>> RegisterNewEmployee(RegisterEmployeeDto registerEmployee)
        {
            if (await IdentityExists(registerEmployee.Identity)) return BadRequest("Identity is taken !");
            if (await EmailExists(registerEmployee.Email)) return BadRequest("Email is taken !");
            if (await MobileExists(registerEmployee.Mobile1)) return BadRequest("Mobile is taken !");

            var employee = new Employee
            {
                FullName = registerEmployee.FullName,
                FullNameAr = registerEmployee.FullNameAr,
                BirthDate = registerEmployee.BirthDate,
                Identity = registerEmployee.Identity,
                ExpiredIdentity = registerEmployee.ExpiredIdentity,
                Passport = registerEmployee.Passport,
                ExpiredPassport = registerEmployee.ExpiredPassport,
                Email = registerEmployee.Email,
                Mobile1 = registerEmployee.Mobile1,
                Mobile2 = registerEmployee.Mobile2,
                EmployeeCountryId = registerEmployee.EmployeeCountryId,
                BirthCountryId = registerEmployee.BirthCountryId,
                Qualification = registerEmployee.Qualification,
                SpecialtyId = registerEmployee.SpecialtyId,
                JobId = registerEmployee.JobId,
                YearsExperience = registerEmployee.YearsExperience
            };
            _context.Add(employee);
            await _context.SaveChangesAsync();
            
            /*
            * Create new User of current employee
            */
            int id = employee.Id;
            string Password;
            var newPassword = new PasswordGenerator();
            Password = newPassword.GeneratePassword(true, true, true, 5);

            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerEmployee.Identity,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password)),
                PasswordSalt = hmac.Key,
                Mobile = registerEmployee.Mobile1,
                Actor = Actor.Employee
            };

            _context.Add(user);
            await _context.SaveChangesAsync();
            await _employeeService.UpdateEmployeeUser(id, user);

            //return employee;
            return new EmployeeDto
            {
                FullName = registerEmployee.FullName,
                Identity = registerEmployee.Identity,
                Email = registerEmployee.Email,
                Mobile1 = registerEmployee.Mobile1
            };
        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterUserDto registerUser)
        {
            if (await UserExists(registerUser.Username.ToLower())) return BadRequest("Username is taken !");

            string Password;
            var newPassword = new PasswordGenerator();
            Password = newPassword.GeneratePassword(true, true, true, 5);

            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerUser.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password)),
                PasswordSalt = hmac.Key,
                Mobile = registerUser.Mobile,
                Actor = registerUser.Actor
            };

            _context.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                Username = registerUser.Username.ToLower(),
                Actor = user.Actor
            };
        }
/*      [HttpPost("createUser")]
        public async Task<ActionResult<UserDto>> CreateUser(int id)
        {
            string identity = await _context.Employees
                            .Where(e => e.Id == id)
                            .Select(e => e.Identity)
                            .SingleOrDefaultAsync();

            string mobile = await _context.Employees
                            .Where(e => e.Id == id)
                            .Select(e => e.Mobile1)
                            .SingleOrDefaultAsync();

            if (await UserExists(identity)) return BadRequest("Username is taken !");

            string Password;
            var newPassword = new PasswordGenerator();
            Password = newPassword.GeneratePassword(true, true, true, 5);

            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = identity,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password)),
                PasswordSalt = hmac.Key,
                Mobile = mobile,
                Actor = Actor.Employee
            };

            _context.Add(user);
            await _context.SaveChangesAsync();
            await _employeeService.UpdateEmployeeUser(id, user);
            return new UserDto
            {
                Username = identity,
                Actor = user.Actor
            };
            
        }*/

        //Check if username is exists
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        } 
        private async Task<bool> IdentityExists(string identity)
        {
            return await _context.Employees.AnyAsync(x => x.Identity == identity.ToLower());
        }
        private async Task<bool> MobileExists(string mobile)
        {
            return await _context.Employees.AnyAsync(x => x.Mobile1 == mobile.ToLower());
        }
        private async Task<bool> EmailExists(string email)
        {
            return await _context.Employees.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}