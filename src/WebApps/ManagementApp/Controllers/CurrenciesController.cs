using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.Currency;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper; 

        public CurrenciesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Currencies.Include(c => c.Country);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<CurrencyViewModel>()));
        }

        // GET: Currencies/Details/5
        public async Task<IActionResult> Details(int id)
        {
           

            var currency = await _context.Currencies
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CurrencyViewModel>(currency));
        }

        // GET: Currencies/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurrencyName,Symbol,DecimalCount,CountryId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", currency.CountryId);
            return View(_mapper.Map<CurrencyViewModel>(currency));
        }

        // GET: Currencies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", currency.CountryId);
            return View(_mapper.Map<CurrencyViewModel>(currency));
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurrencyName,Symbol,DecimalCount,CountryId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Currency currency)
        {
            if (id != currency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyExists(currency.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", currency.CountryId);
            return View(_mapper.Map<CurrencyViewModel>(currency));
        }

        // GET: Currencies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var currency = await _context.Currencies
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currency == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CurrencyViewModel>(currency));
        }

        // POST: Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyExists(int id)
        {
            return _context.Currencies.Any(e => e.Id == id);
        }
    }
}
