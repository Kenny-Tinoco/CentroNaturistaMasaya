using System;
using System.Globalization;

namespace Domain.Utilities
{
    public class DateUtilities
    {
        private string dateFormat = "d/M/yyyy";

        public Date getToday()
        {
            return convertDateTimeToDate(DateTime.Now);
        }
        
        public DateTime convertDateToDateTime(Date parameter)
        {
            return Convert.ToDateTime(parameter.ToString());
        }

        public Date convertDateTimeToDate(DateTime? parameter)
        {
            DateTime date;
            if (parameter == null)
                return null;
            else
                date = (DateTime)parameter;

            //var dateTime = DateTime.ParseExact(parameter.ToString(), dateFormat, CultureInfo.InvariantCulture);

            //return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
            return new Date(date.Day, date.Month, date.Year);
        }
    }
}
