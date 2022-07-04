using CollegeSemesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Interfaces
{
    public interface IClassRepository
    {
        ICollection<Class> GetClasses();
        Class GetClass(long id);
        Class GetClass(string name);
        bool ClassExists(long id);
        bool CreateClass(Class classe);
        bool UpdateClass(Class classe);
        bool DeleteClass(Class classe);
        bool Save();
    }
}
