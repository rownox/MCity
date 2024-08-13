using System.Net.Http.Json;

namespace MCity.Client.Services {
   public class LearnTopicService : ILearnTopicService {

      private readonly HttpClient _httpClient;

      public LearnTopicService(HttpClient httpClient) {
         _httpClient = httpClient;
      }

      public async Task<IEnumerable<Topic?>> AddTopic(Topic learnTopic) {
         return await _httpClient.GetFromJsonAsync<IEnumerable<Topic>>("api/LearnTopic");
      }

      public async Task<IEnumerable<Topic>> GetAllTopics() {
         return await _httpClient.GetFromJsonAsync<IEnumerable<Topic>>("api/LearnTopic");
      }
   }
}
