using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SPA.Models.Email
{
    public class Credentials
    {
        //public static readonly string adresseMail = "nathalierey67@gmail.com";
        public static readonly string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailModify, "https://www.googleapis.com/auth/contacts.readonly" };
        public static readonly string ApplicationName = "Gmail API .NET Quickstart";
        public static readonly string path = @"c:\temp\MyTest.txt";

        /// <summary>
        /// lit les credentials dans le fichier credentials.json
        /// </summary>
        /// <returns></returns>
        public static UserCredential GetCredential()
        {
            UserCredential credential;
            using (var stream =
                    new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            return credential;
        }
    }
}
