using Microsoft.Extensions.Configuration;
using UfcFightCard;
using UfcFightCard.Constants;

var config = new ConfigurationBuilder()
               .AddJsonFile(Url.Config, false)
               .Build();

var ufcCardDetails = UfcEventsScraper.GetLatestUfcCardDetails();
if(ufcCardDetails.LatestCardUrl!= null)
{
    var fightCardContent = UfcEventsScraper.GetUfcMainCardContent(ufcCardDetails.LatestCardUrl);
}

Console.WriteLine(ufcCardUrl);