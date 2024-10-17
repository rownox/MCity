namespace MCity.Helpers {
   public class LearnPageState : ILearnPageState {
      public HashSet<int> OpenTopicIds { get; } = new HashSet<int>();
      public int? SelectedPageId { get; set; }

      public void ToggleTopicVisibility(int topicId) {
         if (OpenTopicIds.Contains(topicId)) {
            OpenTopicIds.Remove(topicId);
         } else {
            OpenTopicIds.Add(topicId);
         }
      }
   }
}
