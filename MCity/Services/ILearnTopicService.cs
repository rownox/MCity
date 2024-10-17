using MCity.Models;

namespace MCity.Services {
   public interface ILearnTopicService {
      Task<List<LearnTopic>> GetAllTopics();
      Task<List<LearnTopic>> GetTopLevelTopics();
      Task<LearnTopic?> AddTopic(LearnTopic learnTopic);
      Task<LearnTopic?> GetTopicById(int id);
   }
}
