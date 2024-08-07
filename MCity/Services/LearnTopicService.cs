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

      public async Task<LearnTopic?> AddTopic(LearnTopic learnTopic, LearnPage learnPage) {
         _logger.LogInformation($"AddTopic called. LearnTopic.Title: {learnTopic.Title}, LearnPage.Title: {learnPage.Title}");

         using var transaction = await _context.Database.BeginTransactionAsync();
         try {
            _context.LearnTopics.Add(learnTopic);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"LearnTopic added. Id: {learnTopic.Id}");

            learnPage.LearnTopicId = learnTopic.Id;
            learnPage.LearnTopic = learnTopic;
            _context.LearnPages.Add(learnPage);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"LearnPage added. Id: {learnPage.Id}");

            learnTopic.HomePageId = learnPage.Id;
            learnTopic.HomePage = learnPage;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"LearnTopic updated with HomePage");

            await transaction.CommitAsync();
            _logger.LogInformation("Transaction committed");

            return learnTopic;
         } catch (Exception ex) {
            _logger.LogError($"Error in AddTopic: {ex.Message}");
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
