using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.DAL.Context;

namespace TopLearn.Core.Code_Generator
{
    public class ShortKeyUrlGenerator
    {
       
        public static string Generate(int length)
        {
            var shortKey = Guid.NewGuid().ToString().Trim().Replace("-", "").Substring(0, length);
            
            return shortKey;
        }
    }
}
