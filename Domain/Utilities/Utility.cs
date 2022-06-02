namespace Domain.Utilities
{
    public static class Utility
    {
        public static T? Find<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var current in enumerable)
                if (predicate(current)) return current;

            return default;
        }
    }

    public enum Position
    {
        administrator,
        seller
    }

    public enum Views
    {
        All,
        OnlyActive,
        OnlyInactive
    }

    public enum RegistrationResult
    {
        Success,
        PasswordDoNotMatch,
        UsernameAlreadyExists
    }
}
