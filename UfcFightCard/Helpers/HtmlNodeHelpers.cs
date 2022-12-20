using HtmlAgilityPack;
using ScrapySharp.Extensions;
using UfcFightCard.Constants;
using static UfcFightCard.Helpers.NumberHelper;
using static UfcFightCard.Helpers.DateTimeHelper;

namespace UfcFightCard.Helpers
{
    public static class HtmlNodeHelpers
    {
        public static string LeftImage(this HtmlNode htmlNode)
        {
            return htmlNode.CssSelect(Tags.AthleteImage).First().Attributes[Tags.Src].Value.Trim();
        }
        public static string RightImage(this HtmlNode htmlNode)
        {
            return htmlNode.CssSelect(Tags.AthleteImage).ToList()[1].Attributes[Tags.Src].Value.Trim();
        }
        public static string LeftName(this HtmlNode htmlNode)
        {
            try
            {
                var givenName = htmlNode.CssSelect(Tags.FullNameRed).ToList()[0].CssSelect(Tags.GivenName).ToList()[0].InnerHtml;
                var familyName = htmlNode.CssSelect(Tags.FullNameRed).ToList()[0].CssSelect(Tags.FamilyName).ToList()[0].InnerHtml;
                return $"{givenName.Trim()} {familyName.Trim()}";
            }
            catch
            {
                var name = htmlNode.CssSelect(Tags.FullNameRed).ToList()[0].InnerHtml;
                return $"{name.Trim()}";
            }
        }
        public static string RightName(this HtmlNode htmlNode)
        {
            try
            {
                var givenName = htmlNode.CssSelect(Tags.FullNameBlue).ToList()[0].CssSelect(Tags.GivenName).ToList()[0].InnerHtml;
                var familyName = htmlNode.CssSelect(Tags.FullNameBlue).ToList()[0].CssSelect(Tags.FamilyName).ToList()[0].InnerHtml;
                return $"{givenName.Trim()} {familyName.Trim()}";
            }
            catch
            {
                var name = htmlNode.CssSelect(Tags.FullNameBlue).ToList()[0].InnerHtml;
                return $"{name.Trim()}";
            }
        }
        public static string WeightClass(this HtmlNode htmlNode)
        {
            try
            {
                return htmlNode.CssSelect(Tags.WeightClass).First().InnerHtml;
            }
            catch
            {
                return "N/a";
            }
        }
        public static List<HtmlNode> Fights(List<HtmlNode> htmlNode)
        {
            return htmlNode[0].Descendants(Tags.Li)
                .Where(node => node.GetAttributeValue(Tags.Class, "").Contains(Tags.Rows))
                .ToList();
        }
        public static List<HtmlNode> UnorderedList(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.Descendants(Tags.Ul)
                .Where(node => node.GetAttributeValue(Tags.Class, "").Contains(Tags.Fights))
                .ToList();
        }
        public static List<HtmlNode> LatestCard(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.Descendants(Tags.Div)
                .Where(node => node.GetAttributeValue(Tags.Class, "").Contains(Tags.CardLogo))
                .ToList();
        }
        public static DateTime CardTimeStamp(HtmlDocument htmlDoc)
        {
            var doc = htmlDoc.DocumentNode.Descendants(Tags.Div)
                .Where(node => node.GetAttributeValue(Tags.Class, "").Contains(Tags.CardInfo))
                .ToList();

            var timeStamp = GetMainCardTimeStamp(doc);
            return timeStamp;
        }
        public static DateTime GetMainCardTimeStamp(List<HtmlNode> htmlNode)
        {
            var timeStamp = htmlNode[0].SelectSingleNode(Tags.Div).GetAttributeValue(Tags.TimeStamp, "");
            var jsConvertedTimeStamp = JsTimeConverter(timeStamp);
            return jsConvertedTimeStamp; ;
        }
        public static string MainCardUrl(List<HtmlNode> htmlNode)
        {
            return htmlNode[0].SelectSingleNode(Tags.A).GetAttributeValue(Tags.Href, "");
        }
    }
}
