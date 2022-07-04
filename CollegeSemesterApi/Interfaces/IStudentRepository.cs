using CollegeSemesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudent(long id);
        Student GetStudent(string name);
        bool StudentExists(long id);
        bool CreateStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool Save();
    }
}
