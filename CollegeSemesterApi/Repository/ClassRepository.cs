using CollegeSemesterApi.Data;
using CollegeSemesterApi.Interfaces;
using CollegeSemesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContext _context;

        public ClassRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Class> GetClasses()
        {
            return _context.Classes.OrderBy(p => p.Id).ToList();
        }

        public Class GetClass(long id)
        {
            return _context.Classes.Where(p => p.Id == id).FirstOrDefault();
        }

        public Class GetClass(string name)
        {
            return _context.Classes.Where(p => p.Name == name).FirstOrDefault();
        }

        public bool ClassExists(long id)
        {
            return _context.Classes.Any(p => p.Id == id);
        }

        public bool CreateClass(Class classe)
        {
            _context.Add(classe);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClass(Class classe)
        {
            _context.Update(classe);
            return Save();
        }

        public bool DeleteClass(Class classe)
        {
            _context.Remove(classe);
            return Save();
        }
    }
}
