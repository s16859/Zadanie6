using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie6.Models;

namespace Zadanie6.Services
{
    public interface StudentService
    {
        public Student getStudentByIndex(String index);
        public List<Student> getStudents();
    }
}
