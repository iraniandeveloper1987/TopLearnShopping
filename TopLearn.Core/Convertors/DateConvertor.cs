using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TopLearn.Core.Convertors
{
    public static class DateConvertor
    {
        public static string MiladiToShamsi(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return persianCalendar.GetYear(dateTime) + "/" + persianCalendar.GetMonth(dateTime).ToString("00") + "/" +
                   persianCalendar.GetDayOfMonth(dateTime).ToString("00");
        }

        public static DateTime ShamsiToMIladi(this string shamsiDate)
        {
            string[] std = shamsiDate.Split('/');
            var result = new DateTime(int.Parse(std[0]),
                int.Parse(std[1]),
                int.Parse(std[2]),
                new PersianCalendar());

            return result;

        }
    }
}
