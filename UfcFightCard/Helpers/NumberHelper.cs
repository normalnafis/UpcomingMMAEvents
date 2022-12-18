using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfcFightCard.Helpers
{
    public static class NumberHelper
    {
        public static long StringToLong (string str)
        {
            long num = (long)Convert.ToDouble(str);
            return num;
        }
    }
}
