using api.DTOs;
using api.DTOs.HMS;
using api.DTOs.SIS;
using api.DTOs.UMS;
using api.Models;
using api.Models.HumanResource;
using api.Models.SchoolManagement;
using api.Models.UserManagment;
using AutoMapper;

namespace api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryDto>();
            /*
             * School
             */
            CreateMap<School, SchoolDto>();
            CreateMap<AddSchoolDto, SchoolDto>();
            CreateMap<Section, SectionDto>();
            CreateMap<AddSectionDto, Section>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<AddDepartmentDto, Department>();
            CreateMap<Grade, GradeDto>();
            CreateMap<AddGradeDto, Grade>();
            CreateMap<OtherSchool, OtherSchoolDto>();
            CreateMap<AddOtherSchoolDto, OtherSchool>();
            /*
             * HRMS
             */
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest=> dest.CountryName, opt=> opt.MapFrom(src=>
                src.EmployeeCountry.Name))
                .ForMember(dest=> dest.BirthPlace, opt=> opt.MapFrom(src=>
                src.BirthCountry.Name))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src =>
                src.Job.Title))
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src =>
                src.Specialty.Name));
            CreateMap<RegisterEmployeeDto, Employee>();
            CreateMap<Document, DocumentDto>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Job, JobDto>();
            CreateMap<AddJobDto, Job>();
            CreateMap<JobDto, EmployeeDto>()
            .ForMember(dest=> dest.FullName, opt => opt.MapFrom(src =>
            src.Employees));
            /*
             * UMS
             */
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<UpdateUserDto, User>();  



            
        }
    }
}