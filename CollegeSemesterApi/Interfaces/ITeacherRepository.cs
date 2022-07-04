using CollegeSemesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Interfaces
{
    public interface ITeacherRepository
    {
        ICollection<Teacher> GetTeachers();
        Teacher GetTeacher(long id);
        Teacher GetTeacher(string name);
        bool TeacherExists(long id);
        bool CreateTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool DeleteTeacher(Teacher teacher);
        bool Save();
    }
}
