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
    public class PriceTagsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly  IMapper _mapper;


        public PriceTagsController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PriceTags
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.PriceTags.Include(p => p.Branch).Include(p => p.City).Include(p => p.Stuff);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<PriceTagViewModel>()));
        }

        // GET: PriceTags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTag = await _context.PriceTags
                .Include(p => p.Branch)
                .Include(p => p.City)
                .Include(p => p.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceTag == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PriceTagViewModel>( priceTag));
        }

        // GET: PriceTags/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name");
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name");
            return View();
        }

        // POST: PriceTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,BranchId,StuffId,Price,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] PriceTag priceTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceTag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", priceTag.BranchId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", priceTag.CityId);
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", priceTag.StuffId);
            return View(_mapper.Map<PriceTagViewModel>(priceTag));
        }

        // GET: PriceTags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTag = await _context.PriceTags.FindAsync(id);
            if (priceTag == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", priceTag.BranchId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", priceTag.CityId);
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", priceTag.StuffId);
            return View(_mapper.Map<PriceTagViewModel>(priceTag));
        }

        // POST: PriceTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,BranchId,StuffId,Price,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] PriceTag priceTag)
        {
            if (id != priceTag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceTag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceTagExists(priceTag.Id))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", priceTag.BranchId);
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", priceTag.CityId);
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", priceTag.StuffId);
            return View(_mapper.Map<PriceTagViewModel>(priceTag));
        }

        // GET: PriceTags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceTag = await _context.PriceTags
                .Include(p => p.Branch)
                .Include(p => p.City)
                .Include(p => p.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceTag == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PriceTagViewModel>(priceTag));
        }

        // POST: PriceTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceTag = await _context.PriceTags.FindAsync(id);
            _context.PriceTags.Remove(priceTag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceTagExists(int id)
        {
            return _context.PriceTags.Any(e => e.Id == id);
        }
    }
}
