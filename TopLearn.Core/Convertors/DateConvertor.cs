using System;
using System.Collections.Generic;
using System.Globalization;
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
    }
}
