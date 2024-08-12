using MCity.Models;

namespace MCity.Services {
   public interface ILearnTopicService {

      Task<List<LearnTopic>> GetAllTopics();

      Task<LearnTopic?> AddTopic(LearnTopic learnTopic);
   }
}
