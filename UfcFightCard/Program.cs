using Microsoft.Extensions.Configuration;
using Razor.Templating.Core;
using UfcFightCard;
using UfcFightCard.Constants;
using UfcFightCard.Misc;
using UfcFightCard.Models;

var config = new ConfigurationBuilder()
               .AddJsonFile(Url.Config, false)
               .Build();

var ufcCardDetails = UfcEventsScraper.GetLatestUfcCardDetails();

    NullChecker.Null(ufcCardDetails.LatestCardUrl);
    var fightCardContent = UfcEventsScraper.GetUfcMainCardContent("https://www.ufc.com/event/ufc-283");
    var html = await RazorTemplateEngine.RenderAsync(Url.razor, fightCardContent);
    var emaildetails = config.GetRequiredSection("Emaildetails").Get<Emaildetails>();
    if (emaildetails != null) { SmtpInitialize.SendEmail(emaildetails, html, ufcCardDetails.MainCardTimeStamp.GetValueOrDefault(DateTime.Now)); }