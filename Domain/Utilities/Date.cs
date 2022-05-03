using System.Diagnostics.Contracts;

namespace Domain.Utilities
{
    public class Date
    {
        public int day;
        public int month;
        public int year;   


        public Date(int day, int month, int year)
        {
            Contract.Requires(validDate(day, month, year));
            this.day = day;
            this.month = month;
            this.year = year;
        }


        private bool validDate(int day, int month, int year)
        {
            bool ok = true;
            return ok;
        }

        public string toString
        {
            get { return day + "/" + month + "/" + year; }
        }
    }
}