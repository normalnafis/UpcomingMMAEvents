using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UfcFightCard.Models;
using static System.Net.Mime.MediaTypeNames;

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

            var ulList = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "").Contains("l-listing__group--bordered"))
                .ToList();

            var listOfFights = ulList[0].Descendants("li")
                .Where(node => node.GetAttributeValue("class", "").Contains("l-listing__item"))
                .ToList();

            var list = new List<UfcFightCardEmail>();
            foreach(var fight in listOfFights)
            {
                var fighCardItem = new UfcFightCardEmail()
                {
                    FighterLeftImage = fight.SelectNodes("//img[@class='image-style-event-fight-card-upper-body-of-standing-athlete']")[0].Attributes["src"].Value,
                    FighterRightImage = fight.SelectNodes("//img[@class='image-style-event-fight-card-upper-body-of-standing-athlete']")[1].Attributes["src"].Value,
                    FighterLeftName = $"{fight.SelectNodes("//span[@class='c-listing-fight__corner-given-name']")[0].InnerText} {fight.SelectNodes("//span[@class='c-listing-fight__corner-family-name']")[0].InnerText}",
                    FighterRightName = $"{fight.SelectNodes("//span[@class='c-listing-fight__corner-given-name']")[1].InnerText} {fight.SelectNodes("//span[@class='c-listing-fight__corner-family-name']")[1].InnerText}",
                    WeightClass = fight.SelectSingleNode("//div[@class='c-listing-fight__class-text']").InnerText
                };
                list.Add(fighCardItem);
            }
            return list;
        }
    }
}
