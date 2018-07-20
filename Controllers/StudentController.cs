using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Formatters;
using Microsoft.AspNetCore.Mvc;

namespace LamarDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IFormatter formatter;
        private List<Student> students = new List<Student>{
            new Student {FirstName="Jean", LastName="Grey"},
            new Student {FirstName="Scott", LastName="Summers"},
        };

        public StudentsController(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] bool fancy)
        {
            return Ok(students.Select(s => formatter.Format(s.FirstName, s.LastName)));
        }
    }
}
