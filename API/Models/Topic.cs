using System.Collections.Generic;

public class Topic {
   public int Id { get; set; }
   public string? Title { get; set; }
   public List<Page> Pages { get; set; } = new List<Page>();
}
