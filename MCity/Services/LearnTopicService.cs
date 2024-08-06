using MCity.Data;
using MCity.Models;
using Microsoft.EntityFrameworkCore;

namespace MCity.Services {
    public class LearnTopicService : ILearnTopicService {

        private readonly ApplicationDbContext _context;

        public LearnTopicService(ApplicationDbContext context) {
            _context = context;
        }

      public async Task<LearnTopic?> AddTopic(LearnTopic learnTopic, LearnPage learnPage) {
         using var transaction = await _context.Database.BeginTransactionAsync();
         try {
            _context.LearnTopics.Add(learnTopic);
            await _context.SaveChangesAsync();

            learnPage.LearnTopicId = learnTopic.Id;
            _context.LearnPages.Add(learnPage);
            await _context.SaveChangesAsync();

            learnTopic.HomePageId = learnPage.Id;
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return learnTopic;
         } catch {
            await transaction.RollbackAsync();
            throw;
         }
      }

      public async Task<List<LearnTopic>> GetAllTopics() {
            var learntopics = await _context.LearnTopics
            .Include(t => t.HomePage)
            .Include(t => t.Pages)
            .ToListAsync();
            return learntopics;
        }
    }
}
