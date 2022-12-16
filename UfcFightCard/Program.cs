using Microsoft.Extensions.Configuration;
using UfcFightCard;

var config = new ConfigurationBuilder()
               .AddJsonFile("C:\\Users\\Nafis Rahman\\source\\repos\\UpcomingMMAEvents\\UfcFightCard\\appsettings.json", false)
               .Build();

var ufcUpcomingEvents = UfcEventsScraper.GetLatestUfcCard();
Console.WriteLine(ufcUpcomingEvents);