using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface ISchoolService
    {
        Task<IEnumerable<SchoolDto>> GetSchools();
        Task<SchoolDto> GetSchool(int id);
        Task<IEnumerable<SchoolDto>> GetSchoolByName(string name);
        Task<SchoolDto> AddSchool(AddSchoolDto addSchool);
        Task<SchoolDto> UpdateSchool(AddSchoolDto updateSchool);
        Task<IEnumerable<SchoolDto>> DeleteSchool(int id);

    }
}