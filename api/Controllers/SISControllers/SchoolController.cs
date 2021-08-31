using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.SIS;
using api.Models;
using api.Services.SIService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers.SISControllers
{
    public class SchoolController : BaseApiController
    {
        private readonly ISchoolService _schoolService;
        private readonly ISectionService _sectionService;
        private readonly IDepartmentService _departmentService;
        private readonly IGradeService _gradeService;
        private readonly IOtherSchoolService _otherSchoolService;
        private readonly DataContext _context;
        public SchoolController(DataContext context, ISchoolService schoolService, ISectionService sectionService, IDepartmentService departmentService, IGradeService gradeService, IOtherSchoolService otherSchoolService)
        {
            _context = context;
            _gradeService = gradeService;
            _departmentService = departmentService;
            _sectionService = sectionService;
            _schoolService = schoolService;
            _otherSchoolService = otherSchoolService;
        }
        /*
         * School
         */
        [HttpGet("GetSchools")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SchoolDto>>>> GetSchools()
        {
            return Ok(await _schoolService.GetSchools());
        }
        [HttpGet("GetSchool/{id}")]
        public async Task<ActionResult<ServiceResponse<SchoolDto>>> GetSchool(int id)
        {
            return Ok(await _schoolService.GetSchool(id));
        }
        [HttpGet("GetSchoolByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SchoolDto>>>> GetSchoolByName(string name)
        {
            return Ok(await _schoolService.GetSchoolByName(name));
        }
        [HttpPost("AddSchool")]
        public async Task<ActionResult<ServiceResponse<SchoolDto>>> AddSchool(AddSchoolDto addSchool)
        {
            if (await SchoolExists(addSchool.Name.ToLower())) return BadRequest("School Name is Exists !");
            if (await NumberExists(addSchool.Number.ToLower())) return BadRequest("School Number is Exists !");
            if (await EmailExists(addSchool.Email.ToLower())) return BadRequest("School Email is Exists !");

            return Ok(await _schoolService.AddSchool(addSchool));
        }
        [HttpPut("UpdateSchool")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SchoolDto>>>> UpdateSchool(AddSchoolDto updateSchool)
        {
            return Ok(await _schoolService.UpdateSchool(updateSchool));
        }
        [HttpDelete("DeleteSchool")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SchoolDto>>>> DeleteSchool(int id)
        {
            return Ok(await _schoolService.DeleteSchool(id));
        }
        /*
         * Section
         */
        [HttpGet("GetSections")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SectionDto>>>> GetSections()
        {
            return Ok(await _sectionService.GetSections());
        }
        [HttpGet("GetSection/{id}")]
        public async Task<ActionResult<ServiceResponse<SectionDto>>> GetSection(int id)
        {
            return Ok(await _sectionService.GetSection(id));
        }
        [HttpGet("GetSectionByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SectionDto>>>> GetSectionByName(string name)
        {
            return Ok(await _sectionService.GetSectionByName(name));
        }
        [HttpPost("AddSection")]
        public async Task<ActionResult<ServiceResponse<SectionDto>>> AddSection(AddSectionDto addSection)
        {
            return Ok(await _sectionService.AddSection(addSection));
        }
        [HttpPut("UpdateSection")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SectionDto>>>> UpdateSection(AddSectionDto updateSection)
        {
            return Ok(await _sectionService.UpdateSection(updateSection));
        }
        [HttpDelete("DeleteSection")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SectionDto>>>> DeleteSection(int id)
        {
            return Ok(await _sectionService.DeleteSection(id));
        }
        /*
         * Department
         */
        [HttpGet("GetDepartments")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<DepartmentDto>>>> GetDepartments()
        {
            return Ok(await _departmentService.GetDepartments());
        }
        [HttpGet("GetDepartment/{id}")]
        public async Task<ActionResult<ServiceResponse<DepartmentDto>>> GetDepartment(int id)
        {
            return Ok(await _departmentService.GetDepartment(id));
        }
        [HttpGet("GetDepartmentByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<DepartmentDto>>>> GetDepartmentByName(string name)
        {
            return Ok(await _departmentService.GetDepartmentByName(name));
        }
        [HttpPost("AddDepartment")]
        public async Task<ActionResult<ServiceResponse<DepartmentDto>>> AddDepartment(AddDepartmentDto addDepartment)
        {
            return Ok(await _departmentService.AddDepartment(addDepartment));
        }
        [HttpPut("UpdateDepartment")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<DepartmentDto>>>> UpdateDepartment(AddDepartmentDto updateDepartment)
        {
            return Ok(await _departmentService.UpdateDepartment(updateDepartment));
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<DepartmentDto>>>> DeleteDepartment(int id)
        {
            return Ok(await _departmentService.DeleteDepartment(id));
        }
        /*
         * Grade
         */
        [HttpGet("GetGrades")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GradeDto>>>> GetGrades()
        {
            return Ok(await _gradeService.GetGrades());
        }
        [HttpGet("GetGrade/{id}")]
        public async Task<ActionResult<ServiceResponse<GradeDto>>> GetGrade(int id)
        {
            return Ok(await _gradeService.GetGrade(id));
        }
        [HttpGet("GetGradeByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GradeDto>>>> GetGradeByName(string name)
        {
            return Ok(await _gradeService.GetGradeByName(name));
        }
        [HttpPost("AddGrade")]
        public async Task<ActionResult<ServiceResponse<GradeDto>>> AddGrade(AddGradeDto addGrade)
        {
            return Ok(await _gradeService.AddGrade(addGrade));
        }
        [HttpPut("UpdateGrade")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GradeDto>>>> UpdateGrade(AddGradeDto updateGrade)
        {
            return Ok(await _gradeService.UpdateGrade(updateGrade));
        }
        [HttpDelete("DeleteGrade")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GradeDto>>>> DeleteGrade(int id)
        {
            return Ok(await _gradeService.DeleteGrade(id));
        }
        /*
         * Other School
         */
        [HttpGet("GetOtherSchool")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<OtherSchoolDto>>>> GetOtherSchool()
        {
            return Ok(await _otherSchoolService.GetOtherSchools());
        }
        [HttpGet("GetOtherSchool/{id}")]
        public async Task<ActionResult<ServiceResponse<OtherSchoolDto>>> GetOtherSchool(int id)
        {
            return Ok(await _otherSchoolService.GetOtherSchool(id));
        }
        [HttpGet("GetOtherSchoolByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<OtherSchoolDto>>>> GetOtherSchoolByName(string name)
        {
            return Ok(await _otherSchoolService.GetOtherSchoolByName(name));
        }
        [HttpPost("AddOtherSchool")]
        public async Task<ActionResult<ServiceResponse<OtherSchoolDto>>> AddOtherSchool(AddOtherSchoolDto addGrade)
        {
            return Ok(await _otherSchoolService.AddOtherSchool(addGrade));
        }
        [HttpPut("UpdateOtherSchool")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<OtherSchoolDto>>>> UpdateOtherSchool(AddOtherSchoolDto updateGrade)
        {
            return Ok(await _otherSchoolService.UpdateOtherSchool(updateGrade));
        }
        [HttpDelete("DeleteOtherSchool")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<OtherSchoolDto>>>> DeleteOtherSchool(int id)
        {
            return Ok(await _otherSchoolService.DeleteOtherSchool(id));
        }
        //======Helper Methods==================
        private async Task<bool> SchoolExists(string name)
        {
            return await _context.Schools.AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }
        private async Task<bool> NumberExists(string number)
        {
            return await _context.Schools.AnyAsync(x => x.Number.ToLower() == number.ToLower());
        }
        private async Task<bool> EmailExists(string email)
        {
            return await _context.Schools.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }
}