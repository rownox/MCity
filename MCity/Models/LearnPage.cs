namespace MCity.Models {
   public class LearnPage {
      public int Id { get; set; }
      public string? Title { get; set; }
      public string? Content { get; set; }
      public string? Source { get; set; }
      public DateOnly DateCreated { get; set; }
      public DateOnly LastEdited { get; set; }
      public string? LastEditedBy { get; set; }
      public string? Contributors { get; set; }

      public int LearnTopicId { get; set; }
      public LearnTopic LearnTopic { get; set; }

   }
}
