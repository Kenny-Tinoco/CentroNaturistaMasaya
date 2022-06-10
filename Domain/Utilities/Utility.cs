using Domain.Entities;

namespace Domain.Utilities
{
    public static class Utilities
    {
        public static T? Find<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            if (enumerable is null)
                return default;

            foreach (var current in enumerable)
                if (predicate(current)) 
                    return current;

            return default;
        }

        public static double GetTotal(this IEnumerable<TransactionDetail> detail, double discount)
        {
            double total = 0;

            foreach (var item in detail)
                total += item.Total;

            return total *= (1 - discount);
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

    public enum Periods
    {
        Today,
        ThisWeek,
        ThisMonth,
        LastSixMonths,
        ThisYear,
        AllTime
    }
}
