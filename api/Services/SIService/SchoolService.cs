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
    public class SchoolService : ISchoolService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SchoolService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<SchoolDto> AddSchool(AddSchoolDto addSchool)
        {
            var otherSchool = new OtherSchool
            {
                Name = addSchool.Name,
                NameAr = addSchool.NameAr
            };
            _context.Add(otherSchool);
            await _context.SaveChangesAsync();
            int OtherSchoolId = otherSchool.Id;

            var school = new School
            {
                Name = addSchool.Name,
                NameAr = addSchool.Name,
                Address = addSchool.Address,
                Logo = addSchool.Logo,
                Number = addSchool.Number,
                Email = addSchool.Email,
                Description = addSchool.Description,
                OtherSchoolId = OtherSchoolId
            };
            _context.Add(school);
            await _context.SaveChangesAsync();
            return new SchoolDto
            {
                Name = addSchool.Name,
                NameAr = addSchool.Name,
                Address = addSchool.Address,
                Logo = addSchool.Logo,
                Number = addSchool.Number,
                Email = addSchool.Email,
                Description = addSchool.Description
            };
        }

        public async Task<IEnumerable<SchoolDto>> DeleteSchool(int id)
        {
            School school = await _context.Schools
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return await _context.Schools
            .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<SchoolDto> GetSchool(int id)
        {
            return await _context.Schools
            .Where(x => x.Id == id)
            .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SchoolDto>> GetSchoolByName(string name)
        {
            return await _context.Schools
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<SchoolDto>> GetSchools()
        {
            return await _context.Schools
            .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<SchoolDto> UpdateSchool(AddSchoolDto updateSchool)
        {
            School school = await _context.Schools
            .FirstOrDefaultAsync(c => c.Id == updateSchool.Id);

            school.Name = updateSchool.Name;
            school.NameAr = updateSchool.Name;
            school.Address = updateSchool.Address;
            school.Logo = updateSchool.Logo;
            school.Number = updateSchool.Number;
            school.Email = updateSchool.Email;
            school.Description = updateSchool.Description;

            await _context.SaveChangesAsync();

            return await _context.Schools
            .Where(x => x.Id == updateSchool.Id)
            .ProjectTo<SchoolDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}