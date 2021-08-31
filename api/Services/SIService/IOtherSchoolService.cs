using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface IOtherSchoolService
    {
        Task<IEnumerable<OtherSchoolDto>> GetOtherSchools();
        Task<OtherSchoolDto> GetOtherSchool(int id);
        Task<IEnumerable<OtherSchoolDto>> GetOtherSchoolByName(string name);
        Task<OtherSchoolDto> AddOtherSchool(AddOtherSchoolDto addOtherSchool);
        Task<OtherSchoolDto> UpdateOtherSchool(AddOtherSchoolDto updateOtherchool);
        Task<IEnumerable<OtherSchoolDto>> DeleteOtherSchool(int id);

    }
}