using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface ITermService
    {
        Task<IEnumerable<TermDto>> GetTerms();
        Task<TermDto> GetTerm(int id);
        Task<IEnumerable<TermDto>> GetTermByName(string name);
        Task<TermDto> AddTerm(AddTermDto addTerm);
        Task<TermDto> UpdateTerm(AddTermDto updateTerm);
        Task<IEnumerable<TermDto>> DeleteTerm(int id);
    }
}