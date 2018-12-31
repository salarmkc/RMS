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
    public class BarcodesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;



        public BarcodesController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Barcodes
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.BarCodes.Include(b => b.Stuff);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<BarcodeViewModel>()));
        }

        // GET: Barcodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barcode = await _context.BarCodes
                .Include(b => b.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barcode == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BarcodeViewModel>( barcode));
        }

        // GET: Barcodes/Create
        public IActionResult Create()
        {
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name");
            return View();
        }

        // POST: Barcodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,BarcodeStuff,StuffId,IsDefault,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Barcode barcode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barcode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", barcode.StuffId);
            return View(_mapper.Map<BarcodeViewModel>(barcode));
        }

        // GET: Barcodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barcode = await _context.BarCodes.FindAsync(id);
            if (barcode == null)
            {
                return NotFound();
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", barcode.StuffId);
            return View(_mapper.Map<BarcodeViewModel>(barcode));
        }

        // POST: Barcodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type,BarcodeStuff,StuffId,IsDefault,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Barcode barcode)
        {
            if (id != barcode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barcode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarcodeExists(barcode.Id))
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
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", barcode.StuffId);
            return View(_mapper.Map<BarcodeViewModel>(barcode));
        }

        // GET: Barcodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barcode = await _context.BarCodes
                .Include(b => b.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barcode == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BarcodeViewModel>(barcode));
        }

        // POST: Barcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barcode = await _context.BarCodes.FindAsync(id);
            _context.BarCodes.Remove(barcode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarcodeExists(int id)
        {
            return _context.BarCodes.Any(e => e.Id == id);
        }
    }
}
