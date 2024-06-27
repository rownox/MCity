using MCity.Data;
using MCity.Models;
using Microsoft.EntityFrameworkCore;

namespace MCity.Services {
    public class LearnPageService : ILearnPageService {

        private readonly ApplicationDbContext _context;

        public LearnPageService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<LearnPage>> GetAllPages() {
            var learnpages = await _context.LearnPages.ToListAsync();
            return learnpages;
        }
    }
}
