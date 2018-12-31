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
    public class StuffSuppliersController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public StuffSuppliersController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: StuffSuppliers
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.StuffSuppliers.Include(s => s.Stuff).Include(s=>s.Supplier);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<StuffSupplierViewModel>()));
        }

        // GET: StuffSuppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffSupplier = await _context.StuffSuppliers
                .Include(s => s.Stuff)
                .Include(s=>s.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuffSupplier == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffSupplierViewModel> (stuffSupplier));
        }

        // GET: StuffSuppliers/Create
        public IActionResult Create()
        {
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return View();
        }

        // POST: StuffSuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuffId,SupplierId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] StuffSupplier stuffSupplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuffSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", stuffSupplier.StuffId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", stuffSupplier.SupplierId);
            return View(_mapper.Map<StuffSupplierViewModel>(stuffSupplier));
        }

        // GET: StuffSuppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffSupplier = await _context.StuffSuppliers.FindAsync(id);
            if (stuffSupplier == null)
            {
                return NotFound();
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", stuffSupplier.StuffId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", stuffSupplier.SupplierId);
            return View(_mapper.Map<StuffSupplierViewModel>(stuffSupplier));
        }

        // POST: StuffSuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StuffId,SupplierId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] StuffSupplier stuffSupplier)
        {
            if (id != stuffSupplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuffSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffSupplierExists(stuffSupplier.Id))
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
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", stuffSupplier.StuffId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", stuffSupplier.SupplierId);
            return View(_mapper.Map<StuffSupplierViewModel>(stuffSupplier));
        }

        // GET: StuffSuppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffSupplier = await _context.StuffSuppliers
                .Include(s => s.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuffSupplier == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffSupplierViewModel>(stuffSupplier));
        }

        // POST: StuffSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stuffSupplier = await _context.StuffSuppliers.FindAsync(id);
            _context.StuffSuppliers.Remove(stuffSupplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffSupplierExists(int id)
        {
            return _context.StuffSuppliers.Any(e => e.Id == id);
        }
    }
}
