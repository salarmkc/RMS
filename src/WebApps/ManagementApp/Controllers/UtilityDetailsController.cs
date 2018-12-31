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
    public class UtilityDetailsController : Controller
    {
        private readonly RmsDbContext _context;
        public readonly IMapper _mapper;

        public UtilityDetailsController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: UtilityDetails
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.UtilityDetails.Include(u => u.Utility);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(), new List<UtilityDetailViewModel>()));
        }

        // GET: UtilityDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilityDetail = await _context.UtilityDetails
                .Include(u => u.Utility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilityDetail == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UtilityDetailViewModel>(utilityDetail));
        }

        // GET: UtilityDetails/Create
        public IActionResult Create()
        {
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName");
            return View();
        }

        // POST: UtilityDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UtilityId,Property,Value,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] UtilityDetail utilityDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utilityDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName", utilityDetail.UtilityId);
            return View(_mapper.Map<UtilityDetailViewModel>(utilityDetail));
        }

        // GET: UtilityDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilityDetail = await _context.UtilityDetails.FindAsync(id);
            if (utilityDetail == null)
            {
                return NotFound();
            }
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName", utilityDetail.UtilityId);
            return View(_mapper.Map<UtilityDetailViewModel>(utilityDetail));
        }

        // POST: UtilityDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UtilityId,Property,Value,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] UtilityDetail utilityDetail)
        {
            if (id != utilityDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilityDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilityDetailExists(utilityDetail.Id))
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
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName", utilityDetail.UtilityId);
            return View(_mapper.Map<UtilityDetailViewModel>(utilityDetail));
        }

        // GET: UtilityDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilityDetail = await _context.UtilityDetails
                .Include(u => u.Utility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilityDetail == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UtilityDetailViewModel>(utilityDetail));
        }

        // POST: UtilityDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilityDetail = await _context.UtilityDetails.FindAsync(id);
            _context.UtilityDetails.Remove(utilityDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilityDetailExists(int id)
        {
            return _context.UtilityDetails.Any(e => e.Id == id);
        }
    }
}
