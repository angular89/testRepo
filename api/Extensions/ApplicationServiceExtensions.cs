using api.Data;
using api.Helpers;
using api.Services;
using api.Services.HRService;
using api.Services.SIService;
using api.Services.UMService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            /*
             * School
             */
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IOtherSchoolService, OtherSchoolService>();
            /*
             * HRMS
             */
            services.AddScoped<IEmployeeService, EmployeeService>();
            /*
             * UMS
             */
            services.AddScoped<IUserService, UserService>();
            
            /*
             * Other
             */
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}