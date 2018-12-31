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
    public class PriceConsumersController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public PriceConsumersController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PriceConsumers
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.PriceConsumers.Include(p => p.Stuff);
            return View(_mapper.Map( await rmsDbContext.ToListAsync(),new List<PriceConsumerViewModel>()));
        }

        // GET: PriceConsumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceConsumer = await _context.PriceConsumers
                .Include(p => p.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceConsumer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PriceConsumerViewModel>(priceConsumer));
        }

        // GET: PriceConsumers/Create
        public IActionResult Create()
        {
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name");
            return View();
        }

        // POST: PriceConsumers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StuffId,Price,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] PriceConsumer priceConsumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceConsumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", priceConsumer.StuffId);
            return View(_mapper.Map<PriceConsumerViewModel>(priceConsumer));
        }

        // GET: PriceConsumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceConsumer = await _context.PriceConsumers.FindAsync(id);
            if (priceConsumer == null)
            {
                return NotFound();
            }
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", priceConsumer.StuffId);
            return View(_mapper.Map<PriceConsumerViewModel>(priceConsumer));
        }

        // POST: PriceConsumers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StuffId,Price,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] PriceConsumer priceConsumer)
        {
            if (id != priceConsumer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceConsumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceConsumerExists(priceConsumer.Id))
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
            ViewData["StuffId"] = new SelectList(_context.Stuffs, "Id", "Name", priceConsumer.StuffId);
            return View(_mapper.Map<PriceConsumerViewModel>(priceConsumer));
        }

        // GET: PriceConsumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceConsumer = await _context.PriceConsumers
                .Include(p => p.Stuff)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceConsumer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PriceConsumerViewModel>(priceConsumer));
        }

        // POST: PriceConsumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceConsumer = await _context.PriceConsumers.FindAsync(id);
            _context.PriceConsumers.Remove(priceConsumer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceConsumerExists(int id)
        {
            return _context.PriceConsumers.Any(e => e.Id == id);
        }
    }
}
