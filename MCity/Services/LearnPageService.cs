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
         var learnpages = await _context.LearnPages
         .Include(p => p.LearnTopic)
         .ToListAsync();
         return learnpages;
      }

      public async Task<LearnPage?> GetPageById(int id) {
         var learnPage = await _context.LearnPages.FindAsync(id);
         if (learnPage == null) {
            Console.WriteLine($"No page found with ID {id}");
         }
         return learnPage;
      }


      public async Task UpdatePage(LearnPage learnPage) {
         var trackedEntity = await _context.LearnPages.FindAsync(learnPage.Id);
         if (trackedEntity != null) {
            _context.Entry(trackedEntity).CurrentValues.SetValues(learnPage);
            await _context.SaveChangesAsync();
         } else {
            throw new InvalidOperationException("Entity not found in the database.");
         }
      }



   }
}
