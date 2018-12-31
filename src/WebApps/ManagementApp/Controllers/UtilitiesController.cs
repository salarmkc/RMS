using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Share;
using ApplicationCore.ViewModel.Network;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class UtilitiesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public UtilitiesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Utilities
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Utilities.Include(u => u.NetworkInfo);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<UtilityViewModel>()));
        }

        // GET: Utilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = await _context.Utilities
                .Include(u => u.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utility == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UtilityViewModel>( utility));
        }

        // GET: Utilities/Create
        public IActionResult Create()
        {
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName");
            return View();
        }

        // POST: Utilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,BaseInfoTargetId,MainName,NetworkInfoId,Manufacturer,Model,BaseInfoColorId,BaseInfoNatureId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] ApplicationCore.Entities.Share.Utility utility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", utility.NetworkInfoId);
            return View(_mapper.Map<UtilityViewModel>(utility));
        }

        // GET: Utilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = await _context.Utilities.FindAsync(id);
            if (utility == null)
            {
                return NotFound();
            }
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", utility.NetworkInfoId);
            return View(_mapper.Map<UtilityViewModel>(utility));
        }

        // POST: Utilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,BaseInfoTargetId,MainName,NetworkInfoId,Manufacturer,Model,BaseInfoColorId,BaseInfoNatureId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] ApplicationCore.Entities.Share.Utility utility)
        {
            if (id != utility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilityExists(utility.Id))
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
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", utility.NetworkInfoId);
            return View(_mapper.Map<UtilityViewModel>(utility));
        }

        // GET: Utilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utility = await _context.Utilities
                .Include(u => u.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utility == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UtilityViewModel>(utility));
        }

        // POST: Utilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utility = await _context.Utilities.FindAsync(id);
            _context.Utilities.Remove(utility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilityExists(int id)
        {
            return _context.Utilities.Any(e => e.Id == id);
        }
    }
}
