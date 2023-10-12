using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        [HttpGet]
        public IActionResult GetAllStudents([FromQuery] int since, [FromQuery] int until )
        {
            return Ok(_studentLogic.GetStudents(since,until));
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            return Ok(_studentLogic.GetStudentById(id));
        }

        [AuthorizationFilter]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student? student)
        {
            if (student.Name == "exception")
            {
                throw new Exception("excepcion");
            }
            _studentLogic.InsertStudents(student);
            return CreatedAtAction(nameof(CreateStudent), student);
        }
    }
}
