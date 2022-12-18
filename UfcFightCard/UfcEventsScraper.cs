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
using static UfcFightCard.Constants.Url;

namespace UfcFightCard
{
    public static class UfcEventsScraper
    {
        public static LatestCard GetLatestUfcCardDetails()
        {
            var ufcEventsHtml = HtmlDownloader.DownloadHtml(Events);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(ufcEventsHtml.Result);
            var latestCard = LatestCard(htmlDocument); 
            var link = MainCardUrl(latestCard);
            var timeStamp = CardTimeStamp(htmlDocument);

            var latestCardDetails = new LatestCard()
            {
                LatestCardUrl = Ufc + link,
                MainCardTimeStamp = timeStamp
            };
            return latestCardDetails;
        }
        public static List<UfcFightCardEmail> GetUfcMainCardContent(string url)
        {
            var ufcFightCardHtml = HtmlDownloader.DownloadHtml(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(ufcFightCardHtml.Result);

            var ulList = UnorderedList(htmlDocument);
            var listOfFights = Fights(ulList);
            var fightCardList = FightCardEmailBuilder(listOfFights);

            return fightCardList;
        }

        public static List<UfcFightCardEmail> FightCardEmailBuilder(List<HtmlNode> listOfFights)
        {
            var list = new List<UfcFightCardEmail>();
            foreach (var fight in listOfFights)
            {
                var fightCardItem = new UfcFightCardEmail()
                {
                    FighterLeftImage = fight.LeftImage(),
                    FighterRightImage = fight.RightImage(),
                    FighterLeftName = fight.LeftName(),
                    FighterRightName = fight.RightName(),
                    WeightClass = fight.WeightClass()
                };
                list.Add(fightCardItem);
            }
            return list;
        }
    }
}
