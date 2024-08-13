namespace MCity.Client.Services {
   public interface ILearnTopicService {

      public Task<IEnumerable<Topic>> GetAllTopics();
      Task<IEnumerable<Topic?>> AddTopic(Topic learnTopic);
   }
}
