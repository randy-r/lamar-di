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
    public class ProfessorsController : ControllerBase
    {
        private readonly IFormatter formatter;
        private List<Professor> students = new List<Professor>{
            new Professor {FirstName="Charles", LastName="Xavier"},
            new Professor {FirstName="Ororo", LastName="Munroe"},
        };

        public ProfessorsController(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(students.Select(s => this.formatter.Format(s.FirstName, s.LastName)));
        }
    }
}
