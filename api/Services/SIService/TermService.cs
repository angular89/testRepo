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
    public class TermService : ITermService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TermService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<TermDto> AddTerm(AddTermDto addTerm)
        {
            var term = new Term
            {
                Name = addTerm.Name,
                NameAr = addTerm.NameAr,
                Starting = addTerm.Starting,
                End = addTerm.End,
                YearId = addTerm.YearId
            };
            _context.Add(term);
            await _context.SaveChangesAsync();
            return new TermDto
            {
                Name = addTerm.Name,
                NameAr = addTerm.NameAr,
                Starting = addTerm.Starting,
                End = addTerm.End
            };
        }

        public async Task<IEnumerable<TermDto>> DeleteTerm(int id)
        {
            Term term = await _context.Terms
                .FirstOrDefaultAsync(c => c.Id == id);
            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();

            return await _context.Terms
            .ProjectTo<TermDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<TermDto> GetTerm(int id)
        {
            return await _context.Terms
            .Where(x => x.Id == id)
            .ProjectTo<TermDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TermDto>> GetTermByName(string name)
        {
            return await _context.Terms
            .Where(x => x.Name.ToLower().Contains(name.ToLower()) || x.NameAr.Contains(name))
            .ProjectTo<TermDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<IEnumerable<TermDto>> GetTerms()
        {
            return await _context.Terms
            .ProjectTo<TermDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<TermDto> UpdateTerm(AddTermDto updateTerm)
        {
            Term term = await _context.Terms
            .FirstOrDefaultAsync(c => c.Id == updateTerm.Id);

            term.Name = updateTerm.Name;
            term.NameAr = updateTerm.NameAr;
            term.Starting = updateTerm.Starting;
            term.End = updateTerm.End;
            term.YearId = updateTerm.YearId;

            await _context.SaveChangesAsync();

            return await _context.Terms
            .Where(x => x.Id == updateTerm.Id)
            .ProjectTo<TermDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
    }
}