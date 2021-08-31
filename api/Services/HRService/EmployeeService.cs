using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.HMS;
using api.Models.HumanResource;
using api.Models.UserManagment;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Services.HRService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<IEnumerable<EmployeeDto>> GetEmployeeByFullName(string fullname)
        {
            return await _context.Employees
            .Where(x => x.FullName.ToLower().Contains(fullname.ToLower()) || x.FullNameAr.Contains(fullname))
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<EmployeeDto> GetEmployeeByIdentity(string identity)
        {
            return await _context.Employees
            .Where(x => x.Identity == identity)
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            return await _context.Employees
            .Where(x => x.Id == id)
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            return await _context.Employees
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployee)
        {
            Employee employee = await _context.Employees
            .FirstOrDefaultAsync(c => c.Id == updateEmployee.Id);
        
            employee.FullName = updateEmployee.FullName;
            employee.FullNameAr = updateEmployee.FullNameAr;
            employee.BirthDate = updateEmployee.BirthDate;
            employee.Identity = updateEmployee.Identity;
            employee.ExpiredIdentity = updateEmployee.ExpiredIdentity;
            employee.Passport = updateEmployee.Passport;
            employee.ExpiredPassport = updateEmployee.ExpiredPassport;
            employee.Email = updateEmployee.Email;
            employee.Mobile1 = updateEmployee.Mobile1;
            employee.Mobile2 = updateEmployee.Mobile2;
            employee.EmployeeCountryId = updateEmployee.EmployeeCountryId;
            employee.BirthCountryId = updateEmployee.BirthCountryId;
            employee.Qualification = updateEmployee.Qualification;
            employee.SpecialtyId = updateEmployee.SpecialtyId;
            employee.JobId = updateEmployee.JobId;
            employee.YearsExperience = updateEmployee.YearsExperience;

            await _context.SaveChangesAsync();

            return await _context.Employees
            .Where(x => x.Id == updateEmployee.Id)
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
        public async Task<EmployeeDto> UpdateEmployeeUser(int id, User user)
        {
            Employee employee = await _context.Employees
            .FirstOrDefaultAsync(c => c.Id == id);
        
            employee.User = user;

            await _context.SaveChangesAsync();

            return await _context.Employees
            .Where(x => x.Id == id)
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<EmployeeDto>> DeleteEmployee(int id)
        {
            Employee employee = await _context.Employees
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return await _context.Employees
            .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<JobDto>> GetJobs()
        {
            return await _context.Jobs
            .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<JobDto> GetJob(int id)
        {
            return await _context.Jobs
            .Where(x => x.Id == id)
            .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<JobDto>> GetJobByName(string name)
        {
            return await _context.Jobs
            .Where(x => x.Title.ToLower().Contains(name.ToLower()) || x.TitleAr.Contains(name))
            .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<JobDto> AddJob(AddJobDto addJob)
        {
            var job = new Job
            {
                Title = addJob.Title,
                TitleAr = addJob.TitleAr,
                Description = addJob.Description
            };

            _context.Add(job);
            await _context.SaveChangesAsync();
            return new JobDto
            {
                Title = job.Title,
                TitleAr = job.TitleAr,
                Description = job.Description
            };
        }

        public async Task<JobDto> UpdateJob(JobDto updateJob)
        {
            Job job = await _context.Jobs
            .FirstOrDefaultAsync(c => c.Id == updateJob.Id);
        
            job.Title = updateJob.Title;
            job.TitleAr = updateJob.TitleAr;
            job.Description = updateJob.Description;

            await _context.SaveChangesAsync();

            return await _context.Jobs
            .Where(x => x.Id == updateJob.Id)
            .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<JobDto>> DeleteJob(int id)
        {
            Job job = await _context.Jobs
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return await _context.Jobs
            .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<IEnumerable<JobDto>> GetJobEmployee(string name)
        {
            return await _context.Jobs
            .Include(x=> x.Employees)
            .Where(x => x.Title.ToLower().Contains(name.ToLower()) || x.TitleAr.Contains(name))
            .ProjectTo<JobDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}