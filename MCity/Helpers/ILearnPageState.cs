namespace MCity.Helpers {
   public interface ILearnPageState {
      HashSet<int> OpenTopicIds { get; }
      int? SelectedPageId { get; set; }
      void ToggleTopicVisibility(int topicId);
   }
}
