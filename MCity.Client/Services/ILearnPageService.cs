using API.Models;

namespace MCity.Client.Services {
   public interface ILearnPageService {
      Task<List<LearnPage>> GetAllPages();
      Task<LearnPage?> GetPageById(int id);
      Task<LearnPage?> AddPage(LearnPage learnPage);
      Task<LearnPage?> UpdatePage(LearnPage learnPage);
   }
}
