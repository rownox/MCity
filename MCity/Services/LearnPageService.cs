using MCity.Data;
using MCity.Models;
using Microsoft.EntityFrameworkCore;

namespace MCity.Services {
    public class LearnPageService : ILearnPageService {

        private readonly ApplicationDbContext _context;

        public LearnPageService(ApplicationDbContext context) {
            _context = context;
        }

      public async Task<LearnPage?> AddPage(LearnPage learnPage) {
         _context.LearnPages.Add(learnPage);
         await _context.SaveChangesAsync();
         return learnPage;
      }

      public async Task<List<LearnPage>> GetAllPages() {
            await Task.Delay(1000);
            var learnpages = await _context.LearnPages
            .Include(p => p.LearnTopic)
            .ToListAsync();
            return learnpages;
        }

        public async Task<LearnPage?> GetPageById(int id) {
            var learnpage = await _context.LearnPages.FindAsync(id);
            return learnpage;
        }
    }
}
