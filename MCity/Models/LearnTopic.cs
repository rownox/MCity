namespace MCity.Models {
   public class LearnTopic : IComparable<LearnTopic> {
      public int Id { get; set; }
      public string? Title { get; set; }

      public int? HomePageId { get; set; }
      public LearnPage? HomePage { get; set; }
      public List<LearnPage> Pages { get; set; } = new List<LearnPage>();

      public int CompareTo(LearnTopic? other) {
         if (other == null) return 1;
         return string.Compare(this.Title, other.Title, StringComparison.OrdinalIgnoreCase);
      }
   }
}
