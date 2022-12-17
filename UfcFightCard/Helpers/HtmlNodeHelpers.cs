using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace UfcFightCard.Helpers
{
    public static class HtmlNodeHelpers
    {
        public static string LeftImage(this HtmlNode htmlNode)
        {
            return htmlNode.CssSelect("img.image-style-event-fight-card-upper-body-of-standing-athlete").First().Attributes["src"].Value;
        }
        public static string RightImage(this HtmlNode htmlNode)
        {
            return htmlNode.CssSelect("img.image-style-event-fight-card-upper-body-of-standing-athlete").ToList()[1].Attributes["src"].Value;
        }
        public static string LeftName(this HtmlNode htmlNode)
        {
            var givenName = htmlNode.CssSelect("span.c-listing-fight__corner-given-name").ToList()[0].InnerHtml;
            var familyName = htmlNode.CssSelect("span.c-listing-fight__corner-family-name").ToList()[0].InnerHtml;
            return $"{givenName} {familyName}";
        }
        public static string RightName(this HtmlNode htmlNode)
        {
            var givenName = htmlNode.CssSelect("span.c-listing-fight__corner-given-name").ToList()[1].InnerHtml;
            var familyName = htmlNode.CssSelect("span.c-listing-fight__corner-family-name").ToList()[1].InnerHtml;
            return $"{givenName} {familyName}";
        }
        public static string WeightClass(this HtmlNode htmlNode)
        {
            return htmlNode.CssSelect("div.c-listing-fight__class-text").First().InnerHtml;
        }
        public static List<HtmlNode> Fights(List<HtmlNode> htmlNode)
        {
            return htmlNode[0].Descendants("li")
                .Where(node => node.GetAttributeValue("class", "").Contains("l-listing__item"))
                .ToList();
        }
        public static List<HtmlNode> UnorderedList(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "").Contains("l-listing__group--bordered"))
                .ToList();
        }
        public static List<HtmlNode> LatestCard(HtmlDocument htmlDoc)
        {
            return htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains("c-card-event--result__logo"))
                .ToList();
        }
        public static string MainCardUrl(List<HtmlNode> htmlNode)
        {
            return htmlNode[0].SelectSingleNode("a").GetAttributeValue("href", "");
        }
    }
}
