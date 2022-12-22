using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UfcFightCard.Models;
using UfcFightCard.Misc;

namespace UfcFightCard
{
    public static class SmtpInitialize
    {
        public static void SendEmail(Emaildetails? emaildetails, string html, DateTime cardTimeStamp)
        {
            if(emaildetails == null) { throw new ArgumentNullException("email"); }
            NullChecker.Null(emaildetails.FromEmail);
            NullChecker.Null(emaildetails.ToEmail);
            var Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = emaildetails.FromEmail,
                    Password = emaildetails.Password
                }
            };
            var Message = new MailMessage();
			foreach (var email in emaildetails.ToEmail.ToList())
            {
				var FromEmail = new MailAddress(emaildetails.FromEmail, emaildetails.Name);
				var ToEmail = new MailAddress(email, emaildetails.ToName);
                Message.From = FromEmail;
				Message.Subject = $"Ufc card {cardTimeStamp.ToString("D")}";
				Message.Body = html;
                Message.IsBodyHtml = true;
				Message.To.Add(ToEmail);
			}

            try
            {
                Client.Send(Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
