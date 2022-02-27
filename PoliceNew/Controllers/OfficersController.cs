using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliceNew.Data;
using PoliceNew.Data.Entites;
using PoliceNew.Dtos;

namespace PoliceNew.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OfficersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OfficersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficerDto>>> GetOfficers()
        {
            var officer = await _context
                                      .Officers
                                      .Include(officer => officer.Department)
                                      .ToListAsync();

            var officerDto = _mapper.Map<List<Officers>, List<OfficerDto>>(officer);

            return officerDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfficerDto>> GetOfficers(int id)
        {
            var officers = await _context
                                        .Officers
                                        .Include(x => x.Department)
                                        .FirstOrDefaultAsync(x => x.Id == id);

            var officerDto = _mapper.Map<Officers, OfficerDto>(officers);

            if (officers == null)
            {
                return NotFound();
            }

            return officerDto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficers(int id, OfficerEditCreateDto officerCreateEditDto)
        {
            if (id != officerCreateEditDto.Id)
            {
                return BadRequest();
            }

            var officers = _mapper.Map<OfficerEditCreateDto, Officers>(officerCreateEditDto);

            _context.Entry(officers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Officers>> PostOfficers(OfficerEditCreateDto officerEditCreateDto)
        {
            var officers = _mapper.Map<OfficerEditCreateDto, Officers>(officerEditCreateDto);

            _context.Officers.Add(officers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfficers", new { id = officers.Id }, officers);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficers(int id)
        {
            var officers = await _context.Officers.FindAsync(id);
            if (officers == null)
            {
                return NotFound();
            }

            _context.Officers.Remove(officers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficersExists(int id)
        {
            return _context.Officers.Any(e => e.Id == id);
        }
    }
}
