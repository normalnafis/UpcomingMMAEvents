using Microsoft.Extensions.Configuration;
using UfcFightCard;
using UfcFightCard.Models;

var config = new ConfigurationBuilder()
               .AddJsonFile("C:\\Users\\Nafis Rahman\\source\\repos\\UpcomingMMAEvents\\UfcFightCard\\appsettings.json", false)
               .Build();

var ufcCardUrl = UfcEventsScraper.GetLatestUfcCardUrl();
var fightCardContent = UfcEventsScraper.GetUfcMainCardContent(ufcCardUrl);

Console.WriteLine(ufcCardUrl);