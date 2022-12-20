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
        public static bool ShouldSendEmail(LatestCard card)
        {
            DateTime currentTime = DateTime.Now;
            DateTime targetTime = card.MainCardTimeStamp.GetValueOrDefault(DateTime.Now);
            TimeSpan difference = targetTime.Subtract(currentTime);
            bool isItTimeToSend = false;

            if (difference.TotalDays <= 7) { isItTimeToSend = true; }
            return (card != null) && (isItTimeToSend);
        }
    }
}
