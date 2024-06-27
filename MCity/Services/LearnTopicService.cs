using MCity.Data;
using MCity.Models;
using Microsoft.EntityFrameworkCore;

namespace MCity.Services {
    public class LearnTopicService : ILearnTopicService {

        private readonly ApplicationDbContext _context;

        public LearnTopicService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<LearnTopic>> GetAllTopics() {

            var learntopics = await _context.LearnTopics.ToListAsync();
            return learntopics;
        }
    }
}
