using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI_DependencyInjection.CustomHandler
{
    public class SeesionIDHandler : DelegatingHandler
    {
        public static string sessionIdToken = "session-id";

        async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string sessionId;
            var cookie = request.Headers.GetCookies(sessionIdToken).FirstOrDefault();
            if (cookie == null) { sessionId = Guid.NewGuid().ToString(); }
            else {
                sessionId = cookie[sessionIdToken].Value;
                try
                {
                    Guid guid = Guid.Parse(sessionId);
                }
                catch (FormatException)
                {

                    sessionId = Guid.NewGuid().ToString();
                }
               
            }
            request.Properties[sessionIdToken] = sessionId;
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            response.Headers.AddCookies(new CookieHeaderValue[] { new CookieHeaderValue(sessionIdToken, sessionId) });
            return response;

        }
    }
}