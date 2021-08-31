using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.HMS;
using api.Models;
using api.Models.HumanResource;
using api.Services.HRService;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.HumanResourceControllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(DataContext context, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _context = context;
        }
        [HttpGet("GetEmployees")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<EmployeeDto>>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }
        [HttpGet("GetEmployeeByIdentity/{identity}")]
        public async Task<ActionResult<ServiceResponse<EmployeeDto>>> GetEmployeeByIdentity(string identity)
        {
            return Ok(await _employeeService.GetEmployeeByIdentity(identity));
        }
        [HttpGet("GetEmployeeById/{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeDto>>> GetEmployeeById(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }
        [HttpGet("GetEmployeeByName/{fullname}")]
        public async Task<ActionResult<ServiceResponse<EmployeeDto>>> GetEmployeeByFullName(string fullname)
        {
            return Ok(await _employeeService.GetEmployeeByFullName(fullname));
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<ServiceResponse<EmployeeDto>>> UpdateEmployee(UpdateEmployeeDto updateEmployee)
        {
            return Ok(await _employeeService.UpdateEmployee(updateEmployee));
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<ServiceResponse<EmployeeDto>>> DeleteEmployee(int id)
        {
            return Ok(await _employeeService.DeleteEmployee(id));
        }
        [HttpPost("AddJob")]
        public async Task<ActionResult<JobDto>> AddNewJob(AddJobDto addJob)
        {
            return Ok(await _employeeService.AddJob(addJob));
        }
        [HttpGet("GetJobs")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<JobDto>>>> GetJobs()
        {
            return Ok(await _employeeService.GetJobs());
        }
        [HttpGet("GetJob/{id}")]
        public async Task<ActionResult<ServiceResponse<JobDto>>> GetJob(int id)
        {
            return Ok(await _employeeService.GetJob(id));
        }
        [HttpGet("GetJobByTitle/{title}")]
        public async Task<ActionResult<ServiceResponse<JobDto>>> GetJobByName(string title)
        {
            return Ok(await _employeeService.GetJobByName(title));
        }
        [HttpGet("GetJobEmployee")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<JobDto>>>> GetJobEmployee(string name)
        {
            return Ok(await _employeeService.GetJobEmployee(name));
        }
        [HttpPut("UpdateJob")]
        public async Task<ActionResult<ServiceResponse<JobDto>>> UpdateJob(JobDto updateJob)
        {
            return Ok(await _employeeService.UpdateJob(updateJob));
        }
        [HttpDelete("DeleteJob")]
        public async Task<ActionResult<ServiceResponse<JobDto>>> DeleteJob(int id)
        {
            return Ok(await _employeeService.DeleteJob(id));
        }
    }
}