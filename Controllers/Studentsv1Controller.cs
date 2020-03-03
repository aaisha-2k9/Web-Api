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
    //2  [EnableCors("*","*","*")]
    [Route("api/v1/students")]
    [CustomCorsAttributes]
    public class Studentsv1Controller : ApiController
    {
        private IStudentRepository _repository;
        
        public Studentsv1Controller(IStudentRepository repository)
        {
            this._repository = repository;
        }
        
        
        //StudentRepository _repository = new StudentRepository();
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAllV1());
        }
    }
}
