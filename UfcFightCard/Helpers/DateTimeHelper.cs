using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UfcFightCard.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime JsTimeConverter (string timeStamp)
        {
            var doubleTimeStamp = Convert.ToDouble (timeStamp);
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(doubleTimeStamp);
        }
    }
}
