using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_DependencyInjection.Data;
using System.Web.Http.Cors;
using WebAPI_DependencyInjection.CustomPolicies;

namespace WebAPI_DependencyInjection.Controllers
{
  //  [EnableCors("*","*","*")]
   [CustomCorsAttributes]
   [Route("api/v2/students")]
    public class Studentsv2Controller : ApiController
    {
        private IStudentRepository _repository;
        
        public Studentsv2Controller(IStudentRepository repository)
        {
            this._repository = repository;
        }
        
        
        //StudentRepository _repository = new StudentRepository();
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAllv2());
        }
    }
}
