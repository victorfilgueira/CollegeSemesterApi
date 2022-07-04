using CollegeSemesterApi.Interfaces;
using CollegeSemesterApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        public IActionResult GetTeachers()
        {
            var teachers = _teacherRepository.GetTeachers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teachers);
        }

        [HttpGet("{teacherId}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public IActionResult GetTeacher(int teacherId)
        {
            if (!_teacherRepository.TeacherExists(teacherId))
                return NotFound();

            var teacher = _teacherRepository.GetTeacher(teacherId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(teacher);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTeacher([FromBody] Teacher teacherCreate)
        {
            if (teacherCreate == null)
                return BadRequest(ModelState);

            var teacher = _teacherRepository.GetTeachers()
                .Where(c => c.Name.Trim().ToUpper() == teacherCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (teacher != null)
            {
                ModelState.AddModelError("", "Teacher already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teacherRepository.CreateTeacher(teacherCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

        [HttpPut("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTeacher(int teacherId,
            [FromBody] Teacher updatedTeacher)
        {
            if (updatedTeacher == null)
                return BadRequest(ModelState);

            if (teacherId != updatedTeacher.Id)
                return BadRequest(ModelState);

            if (!_teacherRepository.TeacherExists(teacherId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_teacherRepository.UpdateTeacher(updatedTeacher))
            {
                ModelState.AddModelError("", "Something went wrong updating teacher");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTeacher(int teacherId)
        {
            if (!_teacherRepository.TeacherExists(teacherId))
            {
                return NotFound();
            }

            var teacherToDelete = _teacherRepository.GetTeacher(teacherId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teacherRepository.DeleteTeacher(teacherToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting teacher");
            }

            return NoContent();
        }
    }
}
