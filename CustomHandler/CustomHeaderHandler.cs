using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI_DependencyInjection.CustomHandler
{
    public class CustomHeaderHandler: DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request,cancellationToken);
            response.Result.Headers.Add("x-custom-header","dtsfdjkl");
            return response;
        }
    }
}