using CollegeSemesterApi.Data;
using CollegeSemesterApi.Interfaces;
using CollegeSemesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateTeacher(Teacher teacher)
        {
            _context.Add(teacher);
            return Save();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _context.Remove(teacher);
            return Save();
        }

        public Teacher GetTeacher(long id)
        {
            return _context.Teachers.Where(p => p.Id == id).FirstOrDefault();
        }

        public Teacher GetTeacher(string name)
        {
            return _context.Teachers.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Teacher> GetTeachers()
        {
            return _context.Teachers.OrderBy(p => p.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TeacherExists(long id)
        {
            return _context.Teachers.Any(p => p.Id == id);
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _context.Update(teacher);
            return Save();
        }
    }
}
