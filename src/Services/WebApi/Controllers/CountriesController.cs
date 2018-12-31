using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities.Static;
using Database;
using Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly RmsDbContext _context;

        public CountriesController(RmsDbContext context)
        {
            _context = context;
        }

        
        // GET api/countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET api/countries/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/countries
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/countries/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/countries/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
