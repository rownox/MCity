namespace MCity.Models {
   public class LearnTopic {
      public int Id { get; set; }
      public string? Title { get; set; }

      public int? HomePageId { get; set; }
      public LearnPage? HomePage { get; set; }
      public List<LearnPage> Pages { get; set; } = new List<LearnPage>();
   }
}
