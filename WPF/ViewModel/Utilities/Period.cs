using Domain.Utilities;

namespace WPF.ViewModel.Utilities
{
    public class Period
    {
        public Period(Periods period, string name)
        {
            this.name = name;
            this.period = period;
        }

        public string name { get; }
        public Periods period { get; }
    }
}
