using CollegeSemesterApi.Interfaces;
using CollegeSemesterApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSemesterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudents()
        {
            var students = _studentRepository.GetStudents();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(students);
        }

        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public IActionResult GetStudent(int studentId)
        {
            if (!_studentRepository.StudentExists(studentId))
                return NotFound();

            var student = _studentRepository.GetStudent(studentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(student);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStudent([FromBody] Student studentCreate)
        {
            if (studentCreate == null)
                return BadRequest(ModelState);

            var student = _studentRepository.GetStudents()
                .Where(c => c.Name.Trim().ToUpper() == studentCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (student != null)
            {
                ModelState.AddModelError("", "Student already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studentRepository.CreateStudent(studentCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

        [HttpPut("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStudent(int studentId,
            [FromBody] Student updatedStudent)
        {
            if (updatedStudent == null)
                return BadRequest(ModelState);

            if (studentId != updatedStudent.Id)
                return BadRequest(ModelState);

            if (!_studentRepository.StudentExists(studentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_studentRepository.UpdateStudent(updatedStudent))
            {
                ModelState.AddModelError("", "Something went wrong updating student");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStudent(int studentId)
        {
            if (!_studentRepository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentToDelete = _studentRepository.GetStudent(studentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studentRepository.DeleteStudent(studentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting student");
            }

            return NoContent();
        }
    }
}
