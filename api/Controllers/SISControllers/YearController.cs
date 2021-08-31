using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.SIS;
using api.Models;
using api.Services.SIService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.SISControllers
{
    public class YearController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IYearService _yearService;
        private readonly ITermService _termService;
        public YearController(DataContext context, IYearService yearService, ITermService termService)
        {
            _termService = termService;
            _yearService = yearService;
            _context = context;
        }
        /*
         * Year
         */
        [HttpGet("GetYears")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<YearDto>>>> GetYears()
        {
            return Ok(await _yearService.GetYears());
        }
        [HttpGet("GetYear/{id}")]
        public async Task<ActionResult<ServiceResponse<YearDto>>> GetYear(int id)
        {
            return Ok(await _yearService.GetYear(id));
        }
        [HttpGet("GetYearByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<YearDto>>>> GetYearByName(string name)
        {
            return Ok(await _yearService.GetYearByName(name));
        }
        [HttpPost("AddYear")]
        public async Task<ActionResult<ServiceResponse<YearDto>>> AddYear(AddYearDto addYear)
        {
            return Ok(await _yearService.AddYear(addYear));
        }
        [HttpPut("UpdateYear")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<YearDto>>>> UpdateYear(AddYearDto updateYear)
        {
            return Ok(await _yearService.UpdateYear(updateYear));
        }
        [HttpDelete("DeleteYear")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<YearDto>>>> DeleteYear(int id)
        {
            return Ok(await _yearService.DeleteYear(id));
        }
        /*
         * Term
         */
        [HttpGet("GetTerms")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TermDto>>>> GetTerms()
        {
            return Ok(await _termService.GetTerms());
        }
        [HttpGet("GetTerm/{id}")]
        public async Task<ActionResult<ServiceResponse<TermDto>>> GetTerm(int id)
        {
            return Ok(await _termService.GetTerm(id));
        }
        [HttpGet("GetTermByName/{name}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TermDto>>>> GetTermByName(string name)
        {
            return Ok(await _termService.GetTermByName(name));
        }
        [HttpPost("AddTerm")]
        public async Task<ActionResult<ServiceResponse<TermDto>>> AddTerm(AddTermDto addTerm)
        {
            return Ok(await _termService.AddTerm(addTerm));
        }
        [HttpPut("UpdateTerm")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TermDto>>>> UpdateTerm(AddTermDto updateTerm)
        {
            return Ok(await _termService.UpdateTerm(updateTerm));
        }
        [HttpDelete("DeleteTerm")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TermDto>>>> DeleteTerm(int id)
        {
            return Ok(await _termService.DeleteTerm(id));
        }
    }
}