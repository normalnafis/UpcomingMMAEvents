using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UfcFightCard.Helpers;
using UfcFightCard.Models;
using static System.Net.Mime.MediaTypeNames;
using static UfcFightCard.Helpers.HtmlNodeHelpers;

namespace UfcFightCard
{
    public static class UfcEventsScraper
    {
        public static string GetLatestUfcCardUrl()
        {
            var ufcEventsHtml = HtmlDownloader.DownloadHtml("https://www.ufc.com/events");
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(ufcEventsHtml.Result);
            var latestCard = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains("c-card-event--result__logo"))
                .ToList();

            var link = latestCard[0].SelectSingleNode("a").GetAttributeValue("href","");
            return @"https://www.ufc.com" + link;
        }
        public static List<UfcFightCardEmail> GetUfcMainCardContent(string url)
        {
            var ufcFightCardHtml = HtmlDownloader.DownloadHtml(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(ufcFightCardHtml.Result);

            var ulList = UnorderedList(htmlDocument);

            var listOfFights = Fights(ulList);

            var list = new List<UfcFightCardEmail>();
            foreach(var fight in listOfFights)
            {
                var fighCardItem = new UfcFightCardEmail()
                {
                    FighterLeftImage = fight.LeftImage(),
                    FighterRightImage = fight.RightImage(),
                    FighterLeftName = fight.LeftName(),
                    FighterRightName = fight.RightName(),
                    WeightClass = fight.WeightClass()
            };
                list.Add(fighCardItem);
            }
            return list;
        }
    }
}
