using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface IYearService
    {
        Task<IEnumerable<YearDto>> GetYears();
        Task<YearDto> GetYear(int id);
        Task<IEnumerable<YearDto>> GetYearByName(string name);
        Task<YearDto> AddYear(AddYearDto addYear);
        Task<YearDto> UpdateYear(AddYearDto updateYear);
        Task<IEnumerable<YearDto>> DeleteYear(int id);
    }
}