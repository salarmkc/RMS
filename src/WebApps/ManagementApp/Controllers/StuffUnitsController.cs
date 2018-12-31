using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using AutoMapper;
using Database;
using ApplicationCore.ViewModel.Stuff;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class StuffUnitsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public StuffUnitsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: StuffUnits
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.StuffUnits.ToListAsync(),new List<StuffUnitViewModel>()));
        }

        // GET: StuffUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffUnit = await _context.StuffUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuffUnit == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffUnitViewModel>(stuffUnit));
        }

        // GET: StuffUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StuffUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LatinName,Value,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] StuffUnit stuffUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuffUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<StuffUnitViewModel>(stuffUnit));
        }

        // GET: StuffUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffUnit = await _context.StuffUnits.FindAsync(id);
            if (stuffUnit == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<StuffUnitViewModel>(stuffUnit));
        }

        // POST: StuffUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LatinName,Value,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] StuffUnit stuffUnit)
        {
            if (id != stuffUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuffUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffUnitExists(stuffUnit.Id))
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
            return View(_mapper.Map<StuffUnitViewModel>(stuffUnit));
        }

        // GET: StuffUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffUnit = await _context.StuffUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuffUnit == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffUnitViewModel>(stuffUnit));
        }

        // POST: StuffUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stuffUnit = await _context.StuffUnits.FindAsync(id);
            _context.StuffUnits.Remove(stuffUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffUnitExists(int id)
        {
            return _context.StuffUnits.Any(e => e.Id == id);
        }
    }
}
