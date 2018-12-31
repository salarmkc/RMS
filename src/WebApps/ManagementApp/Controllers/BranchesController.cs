using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Branch;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class BranchesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public BranchesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Branches
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Branches.Include(b => b.Company).Include(b => b.Measure).Include(b => b.NetworkInfo);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<BranchViewModel>()));
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches
                .Include(b => b.Company)
                .Include(b => b.Measure)
                .Include(b => b.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BranchViewModel>(branch));
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id");
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName");
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,MeasureId,NetworkInfoId,StartDate,EndDate,CommercialCode,RegisterCode,CompanyId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", branch.CompanyId);
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id", branch.MeasureId);
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", branch.NetworkInfoId);
            return View(_mapper.Map<BranchViewModel>(branch));
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", branch.CompanyId);
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id", branch.MeasureId);
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", branch.NetworkInfoId);
            return View(_mapper.Map<BranchViewModel>(branch));
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,MeasureId,NetworkInfoId,StartDate,EndDate,CommercialCode,RegisterCode,CompanyId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Branch branch)
        {
            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", branch.CompanyId);
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id", branch.MeasureId);
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", branch.NetworkInfoId);
            return View(_mapper.Map<BranchViewModel>(branch));
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches
                .Include(b => b.Company)
                .Include(b => b.Measure)
                .Include(b => b.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BranchViewModel>(branch));
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
