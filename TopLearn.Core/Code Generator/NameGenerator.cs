using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.Core.Code_Generator
{
    public class NameGenerator
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
