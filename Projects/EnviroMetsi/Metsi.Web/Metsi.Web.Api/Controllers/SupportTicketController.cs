using System.Collections.Generic;
using Feedback.Core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        // GET: api/<SupportTicketController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SupportTicketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SupportTicketController>
        [HttpPost]
        public string Post([FromBody] TicketModel ticket)
        {
            var x = 0;
            return ticket.FirstName;
        }

        // PUT api/<SupportTicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupportTicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
