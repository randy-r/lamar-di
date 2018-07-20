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
        private readonly IFormatter fancyFormatter;
        private List<Student> students = new List<Student>{
            new Student {FirstName="Jean", LastName="Grey"},
            new Student {FirstName="Scott", LastName="Summers"},
        };

        public StudentsController(IFormatter formatter, IFormatter fancyFormatter)
        {
            this.formatter = formatter;
            this.fancyFormatter = fancyFormatter;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery] bool fancy)
        {
            IFormatter formatterToUse = this.formatter;
            if (fancy == true)
            {
                formatterToUse = this.fancyFormatter;
            }
            return Ok(students.Select(s => formatterToUse.Format(s.FirstName, s.LastName)));
        }
    }
}
