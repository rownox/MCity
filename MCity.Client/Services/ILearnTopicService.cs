using API.Models;

namespace MCity.Client.Services {
   public interface ILearnTopicService {

      Task<List<LearnTopic>> GetAllTopics();

      Task<LearnTopic?> AddTopic(LearnTopic learnTopic);
   }
}
