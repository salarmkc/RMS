using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Warehouse;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public WarehousesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Warehouses
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Warehouses.Include(w => w.Measure);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<WarehouseViewModel>()));
        }

        // GET: Warehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses
                .Include(w => w.Measure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<WarehouseViewModel>(warehouse));
        }

        // GET: Warehouses/Create
        public IActionResult Create()
        {
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id");
            return View();
        }

        // POST: Warehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,BaseInfoActionCode,ManualCode,MeasureId,IsDefault,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id", warehouse.MeasureId);
            return View(_mapper.Map<WarehouseViewModel>(warehouse));
        }

        // GET: Warehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id", warehouse.MeasureId);
            return View(_mapper.Map<WarehouseViewModel>(warehouse));
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,BaseInfoActionCode,ManualCode,MeasureId,IsDefault,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseExists(warehouse.Id))
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
            ViewData["MeasureId"] = new SelectList(_context.Measures, "Id", "Id", warehouse.MeasureId);
            return View(_mapper.Map<WarehouseViewModel>(warehouse));
        }

        // GET: Warehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses
                .Include(w => w.Measure)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<WarehouseViewModel>(warehouse));
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseExists(int id)
        {
            return _context.Warehouses.Any(e => e.Id == id);
        }
    }
}
