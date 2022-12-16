using HtmlAgilityPack;
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
        public static string GetLatestUfcCardUrl()
        {
            var ufcEventsHtml = HtmlDownloader.DownloadEventsHtml("https://www.ufc.com/events");

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(ufcEventsHtml.Result);
            var latestCard = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains("c-card-event--result__logo"))
                .ToList();

            var links = new List<string>();

            var link = latestCard[0].SelectSingleNode("a").GetAttributeValue("href","");
            return @"https://www.ufc.com/" + link;
        }
    }
}
