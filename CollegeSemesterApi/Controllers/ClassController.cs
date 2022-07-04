using CollegeSemesterApi.Interfaces;
using CollegeSemesterApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CollegeSemesterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;

        public ClassController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Class>))]
        public IActionResult GetClasses()
        {
            var classes = _classRepository.GetClasses();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(classes);
        }

        [HttpGet("{classId}")]
        [ProducesResponseType(200, Type = typeof(Class))]
        [ProducesResponseType(400)]
        public IActionResult GetClass(int classId)
        {
            if (!_classRepository.ClassExists(classId))
                return NotFound();

            var classRep = _classRepository.GetClass(classId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(classRep);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClass([FromBody] Class classCreate)
        {
            if (classCreate == null)
                return BadRequest(ModelState);

            var classe = _classRepository.GetClasses()
                .Where(c => c.Name.Trim().ToUpper() == classCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (classe != null)
            {
                ModelState.AddModelError("", "Class already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_classRepository.CreateClass(classCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

        [HttpPut("{classId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClass(int classId,
            [FromBody] Class updatedClass)
        {
            if (updatedClass == null)
                return BadRequest(ModelState);

            if (classId != updatedClass.Id)
                return BadRequest(ModelState);

            if (!_classRepository.ClassExists(classId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_classRepository.UpdateClass(updatedClass))
            {
                ModelState.AddModelError("", "Something went wrong updating class");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{classId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteClass(int classId)
        {
            if (!_classRepository.ClassExists(classId))
            {
                return NotFound();
            }

            var classToDelete = _classRepository.GetClass(classId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_classRepository.DeleteClass(classToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting class");
            }

            return NoContent();
        }
    }
}
