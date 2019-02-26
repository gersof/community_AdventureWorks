using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventureworks.Core.Supervisor.Classes;
using Adventureworks.Entities.Converters;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adventureworks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personSupervisor;

        public PersonController(IPersonRepository personSupervisor)
        {
            _personSupervisor = personSupervisor;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =  await _personSupervisor.GetAllPersons();
            return new ObjectResult(PersonConverter.ConvertList(result));
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
