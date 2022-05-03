using System;
using System.Globalization;

namespace Domain.Utilities
{
    public class TimeUtilities
    {
        private string timeFormat = "hh:mm tt";


        public Time actualTime()
        {
            return convertDateTimeToTime(DateTime.Now);
        }

        public Time convertDateTimeToTime(DateTime? parameter)
        {
            if (parameter == null)
                return null;

            var timeObject = DateTime.ParseExact(parameter.ToString(), timeFormat, CultureInfo.InvariantCulture);

            var time = timeObject.ToString(timeFormat);
            var abbreviation = time.Substring(time.Length-2,2);

            return new Time(timeObject.Hour, timeObject.Minute, abbreviation);
        }
    }
}
