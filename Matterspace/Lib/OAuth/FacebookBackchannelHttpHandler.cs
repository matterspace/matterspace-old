using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Matterspace.Lib.OAuth
{
    /// <summary>
    /// Intercept Facebook request and fix url.
    /// <seealso cref="http://stackoverflow.com/questions/32059384/why-new-fb-api-2-4-returns-null-email-on-mvc-5-with-identity-and-oauth-2"/>
    /// </summary>
    public class FacebookBackchannelHttpHandler : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(!request.RequestUri.AbsolutePath.Contains("/oauth"))
            {
                request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}