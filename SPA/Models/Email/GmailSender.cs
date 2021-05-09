using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models.Email
{
    public class GmailSender
    {
        private UserCredential credential;
        private GmailService Service;

        public GmailSender(UserCredential credential)
        {
            this.credential = credential;

            this.Service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = this.credential,
                ApplicationName = "Gmail API .NET Quickstart",
            });
        }

        public void SendEmail(string to, string from, string subject, string body)
        {
            var mailMessage = new System.Net.Mail.MailMessage();
            //mailMessage.From = new System.Net.Mail.MailAddress(from);
            mailMessage.From = new System.Net.Mail.MailAddress(from);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(to);
            var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mailMessage);

            var gmailMessage = new Google.Apis.Gmail.v1.Data.Message
            {
                Raw = Encode(mimeMessage.ToString())
            };

            Google.Apis.Gmail.v1.UsersResource.MessagesResource.SendRequest request = this.Service.Users.Messages.Send(gmailMessage, from);

            request.Execute();
        }

        public static string Encode(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

            return System.Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}
