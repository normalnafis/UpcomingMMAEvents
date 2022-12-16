using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UfcFightCard
{
    public static class UfcEventsScraper
    {
        public static string GetLatestUfcCard()
        {
            var ufcEventsHtml = HtmlDownloader.DownloadHtml("https://www.ufc.com/events");
            return ufcEventsHtml;
        }
    }
}
