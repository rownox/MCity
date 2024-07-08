using MCity.Models;

namespace MCity.Services {
    public interface ILearnPageService {
        Task<List<LearnPage>> GetAllPages();
        Task<LearnPage?> GetPageById(int id);
    }
}
