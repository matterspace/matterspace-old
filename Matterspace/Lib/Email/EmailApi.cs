using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using System.Web.Configuration;

namespace Matterspace.Lib.Email
{
    public static class EmailApi
    {
        /// <summary>
        /// Sends an email using MailGun REST API.
        /// </summary>
        /// <param name="message"></param>
        public static void SendEmail(EmailMessage message)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunApi]),
                Authenticator =
                    new HttpBasicAuthenticator("api",
                        WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunApiSecrectKey])
            };

            var request = new RestRequest();
            request.AddParameter("domain", WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunDomain], ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunFrom]);
            request.AddParameter("to", message.Destination);
            request.AddParameter("subject", message.Subject);
            request.AddParameter("html", message.Body);

            request.Method = Method.POST;
            client.Execute(request);
        }

        /// <summary>
        /// Creates a body for a email with account confirmation link. A template will be loaded and 
        /// the parameters will be replace template's tags.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="link">confirmation link</param>
        /// <param name="body">email body.</param>
        /// <returns>HTML with email data.</returns>
        public static string CreateAccountConfirmationBody(string userName, string link, string body)
        {
            //This file load will be replaced for a cache system.
            var templateData = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lib\\Email\\Templates\\AccountConfirmation.html"));
            templateData = templateData.Replace("{ UserName }", userName);
            templateData = templateData.Replace("{ Link }", link);
            templateData = templateData.Replace("{ Body }", body);

            return templateData;
        }
    }
}