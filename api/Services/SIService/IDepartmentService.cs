using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs.SIS;

namespace api.Services.SIService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartments();
        Task<DepartmentDto> GetDepartment(int id);
        Task<IEnumerable<DepartmentDto>> GetDepartmentByName(string name);
        Task<DepartmentDto> AddDepartment(AddDepartmentDto addDepartment);
        Task<DepartmentDto> UpdateDepartment(AddDepartmentDto updateDepartment);
        Task<IEnumerable<DepartmentDto>> DeleteDepartment(int id);
    }
}