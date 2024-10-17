using MCity.Data;
using MCity.Models;
using Microsoft.EntityFrameworkCore;

namespace MCity.Services {
   public class LearnTopicService : ILearnTopicService {
      private readonly ApplicationDbContext _context;
      private readonly ILogger<LearnTopicService> _logger;

      public LearnTopicService(ApplicationDbContext context, ILogger<LearnTopicService> logger) {
         _context = context;
         _logger = logger;
      }

      public async Task<LearnTopic?> AddTopic(LearnTopic learnTopic) {
         using var transaction = await _context.Database.BeginTransactionAsync();
         LearnPage learnPage = new LearnPage() {
            LearnTopic = learnTopic,
            LearnTopicId = learnTopic.Id,
            Title = "Introduction"
         };
         _context.LearnTopics.Add(learnTopic);
         _context.LearnPages.Add(learnPage);
         await _context.SaveChangesAsync();
         learnTopic.Pages.Add(learnPage);
         await _context.SaveChangesAsync();
         await transaction.CommitAsync();
         return learnTopic;
      }

      public async Task<List<LearnTopic>> GetAllTopics() {
         return await _context.LearnTopics
             .Include(t => t.Pages)
             .Include(t => t.SubTopics)
             .ThenInclude(st => st.Pages)
             .Include(t => t.SubTopics)
             .ThenInclude(st => st.SubTopics)
             .ToListAsync();
      }

      public async Task<List<LearnTopic>> GetTopLevelTopics() {
         return await _context.LearnTopics
             .Where(t => t.ParentTopicId == null)
             .Include(t => t.Pages)
             .Include(t => t.SubTopics)
             .ThenInclude(st => st.Pages)
             .Include(t => t.SubTopics)
             .ThenInclude(st => st.SubTopics)
             .ToListAsync();
      }
   }
}
