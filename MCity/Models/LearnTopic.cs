namespace MCity.Models {
   public class LearnTopic {
      public int Id { get; set; }
      public string Title { get; set; } = string.Empty;
      public List<LearnPage> Pages { get; set; } = new List<LearnPage>();
      public List<LearnTopic> SubTopics { get; set; } = new List<LearnTopic>();

      public int? ParentTopicId { get; set; }
      public LearnTopic? ParentTopic { get; set; }
   }
}
