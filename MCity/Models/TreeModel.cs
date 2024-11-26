namespace MCity.Models {
   public class TreeModel {
      public int Id { get; set; }
      public string Content { get; set; } = string.Empty;

      public int ParentId { get; set; }
      public TreeModel? Parent { get; set; }
      public List<TreeModel> Children { get; set; } = new List<TreeModel>();
   }
}
