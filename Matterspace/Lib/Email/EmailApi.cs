using RestSharp;
using RestSharp.Authenticators;
using System;
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
            var client = new RestClient();
            client.BaseUrl = new Uri(WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunApi]);
            client.Authenticator = new HttpBasicAuthenticator("api", WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunApiSecrectKey]);

            var request = new RestRequest();
            request.AddParameter("domain", WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunDomain], ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", WebConfigurationManager.AppSettings[AppSettingsConstants.MailGunFrom]);
            request.AddParameter("to", message.Destination);
            request.AddParameter("subject", message.Subject);
            request.AddParameter("text", message.Body);

            request.Method = Method.POST;
            client.Execute(request);
        }
    }
}