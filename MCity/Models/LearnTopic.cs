namespace MCity.Models {
   public class LearnTopic {
      public int Id { get; set; }
      public string? Title { get; set; }
      public List<LearnPage> Pages { get; set; } = new List<LearnPage>();
   }
}
