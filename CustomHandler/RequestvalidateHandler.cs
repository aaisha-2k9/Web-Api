using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace WebAPI_DependencyInjection.CustomHandler
{
    public class RequestvalidateHandler :DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response= base.SendAsync(request, cancellationToken);
            if (response.Result.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                var res = new HttpResponseMessage(HttpStatusCode.NotFound) { Content =new StringContent( "Invalid URL" )};
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(res);
                return tsc.Task;
            }

        }
    }
}