using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.SIS;
using api.Models.SchoolManagement;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Services.SIService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<DepartmentDto> AddDepartment(AddDepartmentDto addDepartment)
        {
            var department = new Department
            {
                Name = addDepartment.Name,
                NameAr = addDepartment.Name,
                Address = addDepartment.Address,
                Number = addDepartment.Number,
                Email = addDepartment.Email,
                Description = addDepartment.Description,
                SectionId = addDepartment.SectionId
            };
            _context.Add(department);
            await _context.SaveChangesAsync();
            return new DepartmentDto
            {
                Name = addDepartment.Name,
                NameAr = addDepartment.Name,
                Address = addDepartment.Address,
                Number = addDepartment.Number,
                Email = addDepartment.Email,
                Description = addDepartment.Description
            };
        }

        public async Task<IEnumerable<DepartmentDto>> DeleteDepartment(int id)
        {
            Department department = await _context.Departments
            .FirstOrDefaultAsync(s=> s.Id == id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return await _context.Departments
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<DepartmentDto> GetDepartment(int id)
        {
            return await _context.Departments
            .Where(x => x.Id == id)
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartmentByName(string name)
        {
            return await _context.Departments
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            return await _context.Departments
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<DepartmentDto> UpdateDepartment(AddDepartmentDto updateDepartment)
        {
            Department department = await _context.Departments
            .FirstOrDefaultAsync(c => c.Id == updateDepartment.Id);

            department.Name = updateDepartment.Name;
            department.NameAr = updateDepartment.Name;
            department.Address = updateDepartment.Address;
            department.Number = updateDepartment.Number;
            department.Email = updateDepartment.Email;
            department.Description = updateDepartment.Description;

            await _context.SaveChangesAsync();

            return await _context.Departments
            .Where(x => x.Id == updateDepartment.Id)
            .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}