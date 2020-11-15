using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.Core.Code_Generator
{
    public class ActiveCode
    {
        public static string Generate()
        {
            return new Random().Next(10000000,99999999).ToString();
        }
    }
}
