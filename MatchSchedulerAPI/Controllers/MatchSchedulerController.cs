using MatchSchedulerAPI.Entities;
using MatchSchedulerAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatchSchedulerAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class MatchSchedulerController : ControllerBase
    {
        private IRepository<Category> repository;
        public MatchSchedulerController(IRepository<Category> _repository)
        {
            repository = _repository;
        }
        [HttpGet(Name ="GetCategories")]
        [ProducesResponseType(typeof(IEnumerable<Category>),(int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope("access-as-user");
            return Ok(repository.AsQueryable());
        }

        [HttpPost(Name ="AddCategory")]
        public async Task AddCategory(string name)
        {
            var category = new Category { Name = name };
            await repository.InsertOneAsync(category);
        }

        [HttpGet("{id:length(24)}",Name ="GetCategoryByID")]
        public async Task<ActionResult<Category>> GetCategoryByID(string id)
        {
            return Ok(await repository.FindByIdAsync(id));
        }
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task GetCricketCalendar()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://devru-live-cricket-scores-v1.p.rapidapi.com/calender.php"),
                Headers =
                {
                    { "x-rapidapi-key", "de2f0ac2b5msh337b3462ce7afd1p16ac33jsn87231dae6459" },
                    { "x-rapidapi-host", "devru-live-cricket-scores-v1.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}
