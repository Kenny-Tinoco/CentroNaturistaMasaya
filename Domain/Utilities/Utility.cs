namespace Domain.Utilities
{
    public static class Utility
    {
        public static bool ToBoolean(this Status value)
        {
            return value == Status.active;
        }
        public static Status ToStatus(this bool value)
        {
            if (value)
                return Status.active;
            else
                return Status.inactive;
        }

        public static T Find<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var current in enumerable)
                if (predicate(current)) return current;

            return default(T);
        }
    }
}
