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
    public class YearService : IYearService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public YearService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<YearDto> AddYear(AddYearDto addYear)
        {
            var year = new Year
            {
                Name = addYear.Name,
                NameAr = addYear.NameAr,
                Starting = addYear.Starting,
                End = addYear.End,
            };
            _context.Add(year);
            await _context.SaveChangesAsync();
            return new YearDto
            {
                Name = addYear.Name,
                NameAr = addYear.NameAr,
                Starting = addYear.Starting,
                End = addYear.End
            };
        }

        public async Task<IEnumerable<YearDto>> DeleteYear(int id)
        {
            Year year = await _context.Years
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Years.Remove(year);
            await _context.SaveChangesAsync();

            return await _context.Years
            .ProjectTo<YearDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<YearDto> GetYear(int id)
        {
            return await _context.Years
            .Where(x => x.Id == id)
            .ProjectTo<YearDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<YearDto>> GetYearByName(string name)
        {
            return await _context.Years
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<YearDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<YearDto>> GetYears()
        {
            return await _context.Years
            .ProjectTo<YearDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<YearDto> UpdateYear(AddYearDto updateYear)
        {
            Year year = await _context.Years
            .FirstOrDefaultAsync(c => c.Id == updateYear.Id);

            year.Name = updateYear.Name;
            year.NameAr = updateYear.NameAr;
            year.Starting = updateYear.Starting;
            year.End = updateYear.End;

            await _context.SaveChangesAsync();

            return await _context.Years
            .Where(x => x.Id == updateYear.Id)
            .ProjectTo<YearDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}