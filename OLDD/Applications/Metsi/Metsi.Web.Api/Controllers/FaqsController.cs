using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Models;
using Iqt.Troubleshooting.Data;
using Iqt.Troubleshooting.Entities;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private FaqContext _context;

        public FaqsController(FaqContext context)
        {
            _context = context;
        }

        // GET: api/<FaqController>
        [HttpGet]
        public async Task<PagedResult<QuestionResultModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Question> list = _context.GetAll();

            var newList = new List<QuestionResultModel>();
            foreach (var question in list)
            {
                var faq = new QuestionResultModel()
                {
                    Question = question.QuestionString,
                    Answers = new List<string>()
                };
                foreach (var answer in question.Answers)
                {
                    faq.Answers.Add(answer.AnswerString);   
                }
                newList.Add(faq);
            }

            
            var model = newList.GetPaged<QuestionResultModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<FaqController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FaqController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FaqController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FaqController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
