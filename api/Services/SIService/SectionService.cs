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
    public class SectionService : ISectionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SectionService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<SectionDto> AddSection(AddSectionDto addSection)
        {
            var section = new Section
            {
                Name = addSection.Name,
                NameAr = addSection.Name,
                Address = addSection.Address,
                Logo = addSection.Logo,
                Number = addSection.Number,
                Email = addSection.Email,
                Description = addSection.Description,
                SchoolId = addSection.SchoolId
            };
            _context.Add(section);
            await _context.SaveChangesAsync();
            return new SectionDto
            {
                Name = addSection.Name,
                NameAr = addSection.Name,
                Address = addSection.Address,
                Logo = addSection.Logo,
                Number = addSection.Number,
                Email = addSection.Email,
                Description = addSection.Description
            };
        }

        public async Task<IEnumerable<SectionDto>> DeleteSection(int id)
        {
            Section section = await _context.Sections
            .FirstOrDefaultAsync(s=> s.Id == id);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();

            return await _context.Sections
            .ProjectTo<SectionDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<SectionDto> GetSection(int id)
        {
            return await _context.Sections
            .Where(x => x.Id == id)
            .ProjectTo<SectionDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SectionDto>> GetSectionByName(string name)
        {
            return await _context.Sections
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<SectionDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<SectionDto>> GetSections()
        {
            return await _context.Sections
            .ProjectTo<SectionDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<SectionDto> UpdateSection(AddSectionDto updateSection)
        {
            Section section = await _context.Sections
            .FirstOrDefaultAsync(c => c.Id == updateSection.Id);

            section.Name = updateSection.Name;
            section.NameAr = updateSection.Name;
            section.Address = updateSection.Address;
            section.Logo = updateSection.Logo;
            section.Number = updateSection.Number;
            section.Email = updateSection.Email;
            section.Description = updateSection.Description;

            await _context.SaveChangesAsync();

            return await _context.Schools
            .Where(x => x.Id == updateSection.Id)
            .ProjectTo<SectionDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}