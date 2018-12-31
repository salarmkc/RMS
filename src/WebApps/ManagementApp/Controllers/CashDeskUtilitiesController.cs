using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.CashDesk;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class CashDeskUtilitiesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;


        public CashDeskUtilitiesController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: CashDeskUtilities
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.CashDeskUtilities.Include(c => c.CashDesk).Include(c => c.Utility);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(), new List<CashDeskUtilityViewModel>()));
        }

        // GET: CashDeskUtilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDeskUtility = await _context.CashDeskUtilities
                .Include(c => c.CashDesk)
                .Include(c => c.Utility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashDeskUtility == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CashDeskUtilityViewModel>(cashDeskUtility));
        }

        // GET: CashDeskUtilities/Create
        public IActionResult Create()
        {
            ViewData["CashDeskId"] = new SelectList(_context.CashDesks, "Id", "Name");
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName");
            return View();
        }

        // POST: CashDeskUtilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CashDeskId,UtilityId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] CashDeskUtility cashDeskUtility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDeskUtility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CashDeskId"] = new SelectList(_context.CashDesks, "Id", "Name", cashDeskUtility.CashDeskId);
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName", cashDeskUtility.UtilityId);
            return View(_mapper.Map<CashDeskUtilityViewModel>(cashDeskUtility));
        }

        // GET: CashDeskUtilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDeskUtility = await _context.CashDeskUtilities.FindAsync(id);
            if (cashDeskUtility == null)
            {
                return NotFound();
            }
            ViewData["CashDeskId"] = new SelectList(_context.CashDesks, "Id", "Name", cashDeskUtility.CashDeskId);
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName", cashDeskUtility.UtilityId);
            return View(_mapper.Map<CashDeskUtilityViewModel>(cashDeskUtility));
        }

        // POST: CashDeskUtilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CashDeskId,UtilityId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] CashDeskUtility cashDeskUtility)
        {
            if (id != cashDeskUtility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDeskUtility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDeskUtilityExists(cashDeskUtility.Id))
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
            ViewData["CashDeskId"] = new SelectList(_context.CashDesks, "Id", "Name", cashDeskUtility.CashDeskId);
            ViewData["UtilityId"] = new SelectList(_context.Utilities, "Id", "MainName", cashDeskUtility.UtilityId);
            return View(_mapper.Map<CashDeskUtilityViewModel>(cashDeskUtility));
        }

        // GET: CashDeskUtilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDeskUtility = await _context.CashDeskUtilities
                .Include(c => c.CashDesk)
                .Include(c => c.Utility)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashDeskUtility == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CashDeskUtilityViewModel>(cashDeskUtility));
        }

        // POST: CashDeskUtilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDeskUtility = await _context.CashDeskUtilities.FindAsync(id);
            _context.CashDeskUtilities.Remove(cashDeskUtility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashDeskUtilityExists(int id)
        {
            return _context.CashDeskUtilities.Any(e => e.Id == id);
        }
    }
}
