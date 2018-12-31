using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Stuff;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class WarehouseStuffsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public WarehouseStuffsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: WarehouseStuffs
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.WarehouseStuffs.Include(w => w.Stuff).Include(w => w.Warehouse);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<WarehouseStuffViewModel>()));
        }

        // GET: WarehouseStuffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseStuff = await _context.WarehouseStuffs
                .Include(w => w.Stuff)
                .Include(w => w.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouseStuff == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<WarehouseStuffViewModel>( warehouseStuff));
        }

        // GET: WarehouseStuffs/Create
        public IActionResult Create()
        {
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name");
            return View();
        }

        // POST: WarehouseStuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuffId,WarehouseId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] WarehouseStuff warehouseStuff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouseStuff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", warehouseStuff.StuffId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name", warehouseStuff.WarehouseId);
            return View(_mapper.Map<WarehouseStuffViewModel>(warehouseStuff));
        }

        // GET: WarehouseStuffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseStuff = await _context.WarehouseStuffs.FindAsync(id);
            if (warehouseStuff == null)
            {
                return NotFound();
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", warehouseStuff.StuffId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name", warehouseStuff.WarehouseId);
            return View(_mapper.Map<WarehouseStuffViewModel>(warehouseStuff));
        }

        // POST: WarehouseStuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StuffId,WarehouseId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] WarehouseStuff warehouseStuff)
        {
            if (id != warehouseStuff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouseStuff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseStuffExists(warehouseStuff.Id))
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
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", warehouseStuff.StuffId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Name", warehouseStuff.WarehouseId);
            return View(_mapper.Map<WarehouseStuffViewModel>(warehouseStuff));
        }

        // GET: WarehouseStuffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseStuff = await _context.WarehouseStuffs
                .Include(w => w.Stuff)
                .Include(w => w.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouseStuff == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<WarehouseStuffViewModel>(warehouseStuff));
        }

        // POST: WarehouseStuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warehouseStuff = await _context.WarehouseStuffs.FindAsync(id);
            _context.WarehouseStuffs.Remove(warehouseStuff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseStuffExists(int id)
        {
            return _context.WarehouseStuffs.Any(e => e.Id == id);
        }
    }
}
