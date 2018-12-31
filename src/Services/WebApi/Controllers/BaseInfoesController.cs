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
    public class BaseInfoesController : ControllerBase
    {
        private readonly RmsDbContext _context;

        public BaseInfoesController(RmsDbContext context)
        {
            _context = context;
        }

        // GET: api/BaseInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseInfo>>> GetBaseInfos()
        {
            return await _context.BaseInfos.ToListAsync();
        }

        // GET: api/BaseInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseInfo>> GetBaseInfo(int id)
        {
            var baseInfo = await _context.BaseInfos.FindAsync(id);

            if (baseInfo == null)
            {
                return NotFound();
            }

            return baseInfo;
        }

        // PUT: api/BaseInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaseInfo(int id, BaseInfo baseInfo)
        {
            if (id != baseInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(baseInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaseInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BaseInfoes
        [HttpPost]
        public async Task<ActionResult<BaseInfo>> PostBaseInfo(BaseInfo baseInfo)
        {
            _context.BaseInfos.Add(baseInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaseInfo", new { id = baseInfo.Id }, baseInfo);
        }

        // DELETE: api/BaseInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseInfo>> DeleteBaseInfo(int id)
        {
            var baseInfo = await _context.BaseInfos.FindAsync(id);
            if (baseInfo == null)
            {
                return NotFound();
            }

            _context.BaseInfos.Remove(baseInfo);
            await _context.SaveChangesAsync();

            return baseInfo;
        }

        private bool BaseInfoExists(int id)
        {
            return _context.BaseInfos.Any(e => e.Id == id);
        }
    }
}
