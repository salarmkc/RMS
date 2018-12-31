using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.Log;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class LogTypesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public LogTypesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: LogTypes
        public async Task<IActionResult> Index()
        {
            return View (_mapper.Map(await _context.LogTypes.ToListAsync(),new List<LogTypeViewModel>()));
        }

        // GET: LogTypes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var logType = await _context.LogTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logType == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<LogTypeViewModel>(logType));
            
           
        }

        // GET: LogTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogTypeName,LogTypeEnName,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] LogType logType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<LogTypeViewModel>(logType));
        }

        // GET: LogTypes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           
            var logType = await _context.LogTypes.FindAsync(id);
            if (logType == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<LogTypeViewModel>(logType));
        }

        // POST: LogTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogTypeName,LogTypeEnName,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] LogType logType)
        {
            if (id != logType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogTypeExists(logType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<LogTypeViewModel>(logType));
        }

        // GET: LogTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var logType = await _context.LogTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logType == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<LogTypeViewModel>(logType));
        }

        // POST: LogTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logType = await _context.LogTypes.FindAsync(id);
            _context.LogTypes.Remove(logType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogTypeExists(int id)
        {
            return _context.LogTypes.Any(e => e.Id == id);
        }
    }
}
