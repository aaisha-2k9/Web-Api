using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI_DependencyInjection.CustomHandler;

namespace WebAPI_DependencyInjection.Controllers
{
    public class CookiesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            var cookie = new CookieHeaderValue("session-id",Guid.NewGuid().ToString());
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return response;
            }
        [System.Web.Http.Route("api/getCookieData")]
        public IHttpActionResult GetCookieData()
        {
            var sessionId = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("session-id").FirstOrDefault();
            if (cookie != null) { sessionId = cookie["session-id"].Value; }
            return Ok(sessionId);
        }
        [System.Web.Http.Route("    ")]
        public IHttpActionResult GetCookieHandler()
        {
            string sessionId = Request.Properties[SeesionIDHandler.sessionIdToken] as string;
           
            return Ok(sessionId);
        }

    }
}