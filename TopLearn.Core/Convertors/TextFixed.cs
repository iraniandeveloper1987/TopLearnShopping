using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.Core.Convertors
{
    public static class TextFixed
    {
        public static string EmailFixed(this string email)
        {
            return email.Trim().ToLower();
        }
    }
}
