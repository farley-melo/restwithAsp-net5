using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restwithAsp_net5.Model;
using restwithAsp_net5.Services;

namespace restwithAsp_net5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _ipersonService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _ipersonService = personService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ipersonService.findAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _ipersonService.findById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
          
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_ipersonService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {

            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_ipersonService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _ipersonService.Delete(id);
             return NoContent();
        }









    }
}
