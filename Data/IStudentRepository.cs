using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_DependencyInjection.Models;

namespace WebAPI_DependencyInjection.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Studentv1> GetAllV1();
             IEnumerable<Studentv2> GetAllv2();
        Studentv1 GetStudentById(int id);
    }
}
