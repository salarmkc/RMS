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
    public class CashDesksController : Controller
    {
        private readonly RmsDbContext _context;
        public readonly IMapper _mapper;
        public CashDesksController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: CashDesks
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.CashDesks.Include(c => c.Branch).Include(c => c.NetworkInfo);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<CashDeskViewModel>()));
        }

        // GET: CashDesks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDesk = await _context.CashDesks
                .Include(c => c.Branch)
                .Include(c => c.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashDesk == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CashDeskViewModel>(cashDesk));
        }

        // GET: CashDesks/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name");
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName");
            return View();
        }

        // POST: CashDesks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,NetworkInfoId,BranchId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] CashDesk cashDesk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashDesk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", cashDesk.BranchId);
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", cashDesk.NetworkInfoId);
            return View(_mapper.Map<CashDeskViewModel>(cashDesk));
        }

        // GET: CashDesks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDesk = await _context.CashDesks.FindAsync(id);
            if (cashDesk == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", cashDesk.BranchId);
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", cashDesk.NetworkInfoId);
            return View(_mapper.Map<CashDeskViewModel>(cashDesk));
        }

        // POST: CashDesks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,NetworkInfoId,BranchId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] CashDesk cashDesk)
        {
            if (id != cashDesk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashDesk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashDeskExists(cashDesk.Id))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", cashDesk.BranchId);
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", cashDesk.NetworkInfoId);
            return View(_mapper.Map<CashDeskViewModel>(cashDesk));
        }

        // GET: CashDesks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashDesk = await _context.CashDesks
                .Include(c => c.Branch)
                .Include(c => c.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashDesk == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CashDeskViewModel>(cashDesk));
        }

        // POST: CashDesks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashDesk = await _context.CashDesks.FindAsync(id);
            _context.CashDesks.Remove(cashDesk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashDeskExists(int id)
        {
            return _context.CashDesks.Any(e => e.Id == id);
        }
    }
}
