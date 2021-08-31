using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionDto>> GetSections();
        Task<SectionDto> GetSection(int id);
        Task<IEnumerable<SectionDto>> GetSectionByName(string name);
        Task<SectionDto> AddSection(AddSectionDto addSection);
        Task<SectionDto> UpdateSection(AddSectionDto updateSection);
        Task<IEnumerable<SectionDto>> DeleteSection(int id);
    }
}