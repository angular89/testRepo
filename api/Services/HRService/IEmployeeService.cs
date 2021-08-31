using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.HMS;
using api.Models;
using api.Models.HumanResource;
using api.Models.UserManagment;

namespace api.Services.HRService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<IEnumerable<EmployeeDto>> GetEmployeeByFullName(string fullname);
        Task<EmployeeDto> GetEmployeeByIdentity(string identity);
        Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployee);
        Task<EmployeeDto> UpdateEmployeeUser(int id, User user);
        Task<IEnumerable<EmployeeDto>> DeleteEmployee(int id);
        
        // * Jobs area....
        Task<IEnumerable<JobDto>> GetJobs();
        Task<JobDto> GetJob(int id);
        Task<JobDto> AddJob(AddJobDto addJob);
        Task<IEnumerable<JobDto>> GetJobByName(string name);
        Task<JobDto> UpdateJob(JobDto job);
        Task<IEnumerable<JobDto>> DeleteJob(int id);
        Task<IEnumerable<JobDto>> GetJobEmployee(string name);
        
    }
}