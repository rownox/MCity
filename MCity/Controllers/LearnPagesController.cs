using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCity.Data;
using Shared.Models;

namespace MCity.Server.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class LearnPagesController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public LearnPagesController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearnPage>>> GetLearnPages() {
            return await _context.LearnPages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LearnPage>> GetLearnPage(int id) {
            var learnPage = await _context.LearnPages.FindAsync(id);

            if (learnPage == null) {
                return NotFound();
            }

            return learnPage;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearnPage(int id, LearnPage learnPage) {
            if (id != learnPage.Id) {
                return BadRequest();
            }

            _context.Entry(learnPage).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!LearnPageExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<LearnPage>> PostLearnPage(LearnPage learnPage) {
            _context.LearnPages.Add(learnPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLearnPage), new { id = learnPage.Id }, learnPage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearnPage(int id) {
            var learnPage = await _context.LearnPages.FindAsync(id);
            if (learnPage == null) {
                return NotFound();
            }

            _context.LearnPages.Remove(learnPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LearnPageExists(int id) {
            return _context.LearnPages.Any(e => e.Id == id);
        }
    }
}
