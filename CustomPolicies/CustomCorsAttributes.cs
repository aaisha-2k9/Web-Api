using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace WebAPI_DependencyInjection.CustomPolicies
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public class CustomCorsAttributes : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy policy;
        public CustomCorsAttributes()
        {
            this.policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true
            };
               policy.Origins.Add("https://localhost:44381");
         
           
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(policy);
        }
    }
}