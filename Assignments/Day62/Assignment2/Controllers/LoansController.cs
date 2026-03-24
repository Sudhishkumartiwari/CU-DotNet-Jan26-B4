using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day62.Assignment2.Data;
using Day62.Assignment2.Models;
using Day62.Assignment2.DTOs;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public LoansController(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetLoans()
        {
            var loans = await _context.Loans.ToListAsync();
            return _mapper.Map<List<LoanReadDto>>(loans);
        }

        // GET: api/Loans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanReadDto>> GetLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return _mapper.Map<LoanReadDto>(loan);
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, LoanUpdateDto loanUpdateDto)
        {
            var existingLoan = await _context.Loans.FindAsync(id);
            if (existingLoan == null)
            {
                return NotFound();
            }

            // Map updated values from DTO to the tracked entity
            _mapper.Map(loanUpdateDto, existingLoan);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
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

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanReadDto>> PostLoan(LoanCreateDto loanDto)
        {
            var loanModel = _mapper.Map<Loan>(loanDto);
            
            _context.Loans.Add(loanModel);
            await _context.SaveChangesAsync();

            // Map back to ReadDto to include the generated Id
            var loanReadDto = _mapper.Map<LoanReadDto>(loanModel);

            return CreatedAtAction(nameof(GetLoan), new { id = loanReadDto.Id }, loanReadDto);
        }

        // DELETE: api/Loans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }
    }
}
