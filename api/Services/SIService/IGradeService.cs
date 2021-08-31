using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface IGradeService
    {
        Task<IEnumerable<GradeDto>> GetGrades();
        Task<GradeDto> GetGrade(int id);
        Task<IEnumerable<GradeDto>> GetGradeByName(string name);
        Task<GradeDto> AddGrade(AddGradeDto addGrade);
        Task<GradeDto> UpdateGrade(AddGradeDto updateGrade);
        Task<IEnumerable<GradeDto>> DeleteGrade(int id);
    }
}