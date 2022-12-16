using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
               .AddJsonFile("C:\\Users\\Nafis Rahman\\source\\repos\\UpcomingMMAEvents\\UfcFightCard\\appsettings.json", false)
               .Build();

var ufcUpcomingEvents = "";