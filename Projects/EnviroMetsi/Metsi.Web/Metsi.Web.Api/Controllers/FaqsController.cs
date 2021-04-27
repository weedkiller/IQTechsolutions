using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;

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
        public async Task<PagedResult<QuestionModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Question> list = _context.GetAll();

            var newList = new List<QuestionModel>();

            foreach (var item in list)
            {
                var newItem = new QuestionModel()
                {
                    Id = item.Id,
                    Question = item.QuestionString.HtmlToPlainText()
                };
                foreach (var ans in item.Answers)
                {
                    newItem.Answers.Add(ans.AnswerString );
                }

                newList.Add(newItem);
            }
            
            var model = newList.GetPaged<QuestionModel>(pageNumber, pageSize);
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
