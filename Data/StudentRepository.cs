using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_DependencyInjection.Models;

namespace WebAPI_DependencyInjection.Data
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Studentv1> GetAllV1()
        {
            return GetStudentsFromDbV1();
        }
        public IEnumerable<Studentv2> GetAllv2()
        {
            return GetStudentsFromDbV2();
        }

        public Studentv1 GetStudentById(int id)
        {
            return GetStudentsFromDbV1().FirstOrDefault(n => n.Id == id);
        }

        private IEnumerable<Studentv1> GetStudentsFromDbV1()
        {
            List<Studentv1> students = new List<Studentv1>()
            {
                new Studentv1
                {
                    Id = 1,
                    FullName = "John Smith",
                    GPA = 3.5
                },

                new Studentv1
                {
                    Id = 2,
                    FullName = "Jimmy Wright",
                    GPA = 3.9
                }
            };

            return students;
        }
        private IEnumerable<Studentv2> GetStudentsFromDbV2()
        {
            List<Studentv2> students = new List<Studentv2>()
            {
                new Studentv2
                {
                    Id = 1,
                    FullName = "John Smith",
                    GPA = 3.5,
                    Age=22
                },

                new Studentv2
                {
                    Id = 2,
                    FullName = "Jimmy Wright",
                    GPA = 3.9,
                    Age=24
               
                }
            };

            return students;
        }
    }
}