using CollegeSemesterApi.Data;
using CollegeSemesterApi.Interfaces;
using CollegeSemesterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Student> GetStudents()
        {
            return _context.Students.OrderBy(p => p.Id).ToList();
        }

        public Student GetStudent(long id)
        {
            return _context.Students.Where(p => p.Id == id).FirstOrDefault();
        }

        public Student GetStudent(string name)
        {
            return _context.Students.Where(p => p.Name == name).FirstOrDefault();
        }

        public bool StudentExists(long id)
        {
            return _context.Students.Any(p => p.Id == id);
        }
        public bool CreateStudent(Student student)
        {
            _context.Add(student);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateStudent(Student student)
        {
            _context.Update(student);
            return Save();
        }

        public bool DeleteStudent(Student student)
        {
            _context.Remove(student);
            return Save();
        }
    }
}
