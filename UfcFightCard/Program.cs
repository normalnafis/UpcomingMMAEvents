using Microsoft.Extensions.Configuration;
using UfcFightCard;
using UfcFightCard.Constants;

var config = new ConfigurationBuilder()
               .AddJsonFile(Url.Config, false)
               .Build();

var ufcCardUrl = UfcEventsScraper.GetLatestUfcCardUrl();
var fightCardContent = UfcEventsScraper.GetUfcMainCardContent(ufcCardUrl);

Console.WriteLine(ufcCardUrl);