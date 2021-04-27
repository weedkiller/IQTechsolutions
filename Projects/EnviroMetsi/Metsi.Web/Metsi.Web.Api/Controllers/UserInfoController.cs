using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Filing.Base.Extensions;
using Identity.Base.ApiModels;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private DbContext _context;
        private IApplicationConfiguration _configuration;

        public UserInfoController(DbContext context, IApplicationConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/<UserInfoController>
        [HttpGet]
        public async Task<List<UserInfo>> Get()
        {
            var users = await _context.Set<UserInfo>().Include(c => c.Images).ToListAsync();
            return users;
        }

        // GET api/<UserInfoController>/5
        [HttpGet("{id}")]
        public async Task<UserInfoModel> Get(string id)
        {
            var info = await _context.Set<UserInfo>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);

            return new UserInfoModel()
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                EmailAddress = "",
                ImageUrl = info.GetPath(_configuration.BaseImageUrl, Filing.Base.Enums.ImageType.Cover, _configuration.ImageProfilePlaceholder)
            };
        }

        // POST api/<UserInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
