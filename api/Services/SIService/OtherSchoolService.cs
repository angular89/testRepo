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
    public class OtherSchoolService : IOtherSchoolService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public OtherSchoolService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<OtherSchoolDto> AddOtherSchool(AddOtherSchoolDto addOtherSchool)
        {
            var grade = new OtherSchool
            {
                Name = addOtherSchool.Name,
                NameAr = addOtherSchool.NameAr
            };
            _context.Add(grade);
            await _context.SaveChangesAsync();
            return new OtherSchoolDto
            {
                Name = addOtherSchool.Name,
                NameAr = addOtherSchool.Name
            };
        }

        public async Task<IEnumerable<OtherSchoolDto>> DeleteOtherSchool(int id)
        {
            OtherSchool otherSchool = await _context.OtherSchools
            .FirstOrDefaultAsync(s=> s.Id == id);
            _context.OtherSchools.Remove(otherSchool);
            await _context.SaveChangesAsync();

            return await _context.OtherSchools
            .ProjectTo<OtherSchoolDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<OtherSchoolDto> GetOtherSchool(int id)
        {
            return await _context.OtherSchools
            .Where(x => x.Id == id)
            .ProjectTo<OtherSchoolDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<OtherSchoolDto>> GetOtherSchoolByName(string name)
        {
            return await _context.OtherSchools
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<OtherSchoolDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<OtherSchoolDto>> GetOtherSchools()
        {
            return await _context.OtherSchools
            .ProjectTo<OtherSchoolDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<OtherSchoolDto> UpdateOtherSchool(AddOtherSchoolDto updateOtherchool)
        {
            OtherSchool otherSchool = await _context.OtherSchools
            .FirstOrDefaultAsync(c => c.Id == updateOtherchool.Id);

            otherSchool.Name = updateOtherchool.Name;
            otherSchool.NameAr = updateOtherchool.Name;

            await _context.SaveChangesAsync();

            return await _context.OtherSchools
            .Where(x => x.Id == updateOtherchool.Id)
            .ProjectTo<OtherSchoolDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}