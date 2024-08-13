using MCity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCity.Controllers {
   [Route("api/[controller]")]
   [ApiController]
   public class LearnTopicController : ControllerBase {
      private readonly ILearnTopicService _learnTopicService;

      public LearnTopicController(ILearnTopicService learnTopicService) {
         _learnTopicService = learnTopicService;
      }

      [HttpGet]
      public async Task<IActionResult> GetAllTopics() {
         var topics = await _learnTopicService.GetAllTopics();
         return Ok(topics);
      }
   }
}
