using Microsoft.Extensions.Configuration;
using Razor.Templating.Core;
using UfcFightCard;
using UfcFightCard.Constants;

var config = new ConfigurationBuilder()
               .AddJsonFile(Url.Config, false)
               .Build();

var ufcCardDetails = UfcEventsScraper.GetLatestUfcCardDetails();
if(ufcCardDetails.LatestCardUrl!= null)
{
    var fightCardContent = UfcEventsScraper.GetUfcMainCardContent(ufcCardDetails.LatestCardUrl);
    var html = RazorTemplateEngine.RenderAsync(Url.razor, fightCardContent);
}