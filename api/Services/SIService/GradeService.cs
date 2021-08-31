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
    public class GradeService : IGradeService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GradeService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<GradeDto> AddGrade(AddGradeDto addGrade)
        {
            var grade = new Grade
            {
                Name = addGrade.Name,
                NameAr = addGrade.NameAr,
                DepartmentId = addGrade.DepartmentId
            };
            _context.Add(grade);
            await _context.SaveChangesAsync();
            return new GradeDto
            {
                Name = addGrade.Name,
                NameAr = addGrade.Name
            };
        }

        public async Task<IEnumerable<GradeDto>> DeleteGrade(int id)
        {
            Grade grade = await _context.Grades
            .FirstOrDefaultAsync(s=> s.Id == id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return await _context.Grades
            .ProjectTo<GradeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<GradeDto> GetGrade(int id)
        {
            return await _context.Grades
            .Where(x => x.Id == id)
            .ProjectTo<GradeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<GradeDto>> GetGradeByName(string name)
        {
            return await _context.Grades
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<GradeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<GradeDto>> GetGrades()
        {
            return await _context.Grades
            .ProjectTo<GradeDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<GradeDto> UpdateGrade(AddGradeDto updateGrade)
        {
            Grade grade = await _context.Grades
            .FirstOrDefaultAsync(c => c.Id == updateGrade.Id);

            grade.Name = updateGrade.Name;
            grade.NameAr = updateGrade.Name;

            await _context.SaveChangesAsync();

            return await _context.Grades
            .Where(x => x.Id == updateGrade.Id)
            .ProjectTo<GradeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

    }
}