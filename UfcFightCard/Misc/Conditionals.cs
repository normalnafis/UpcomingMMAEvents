using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcFightCard.Models;

namespace UfcFightCard.Misc
{
    public static class Conditionals
    {
        public static bool ShouldSendEmail(LatestCard card, Emaildetails? emaildetails)
        {
            DateTime currentTime = DateTime.Now;
            DateTime targetTime = DateTime.Now.AddDays(5);//card.MainCardTimeStamp.GetValueOrDefault(DateTime.Now);
            TimeSpan difference = targetTime.Subtract(currentTime);
            bool isItTimeToSend = false;

            if (difference.TotalDays <= 7) { isItTimeToSend = true; }
            return (card != null) && (emaildetails != null) && (isItTimeToSend);
        }
    }
}
