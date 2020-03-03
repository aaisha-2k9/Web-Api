using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI_DependencyInjection.CustomHandler
{
    public class MethodOverrideHandler : DelegatingHandler
    {
        readonly string[] _methods = {"DELETE","PATCH","PUT" };
        const string _headers = "X-HTTP-Method-Override";
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Headers.Contains(_headers))
            {
                var method = request.Headers.GetValues(_headers).FirstOrDefault();
                if (_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase)) {
                    request.Method = new HttpMethod(method);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}