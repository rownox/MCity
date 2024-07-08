namespace MCity.Extensions {
    public static class HashSetExtensions {
        public static void Toggle<T>(this HashSet<T> set, T item) {
            if (!set.Remove(item)) {
                set.Add(item);
            }
        }
    }
}
