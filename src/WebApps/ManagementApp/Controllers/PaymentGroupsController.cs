using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.BaseInfo;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class PaymentGroupsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public PaymentGroupsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PaymentGroups
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.PaymentGroups.Include(p => p.Currency).Include(p => p.Parent);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<PaymentGroupViewModel>()));
        }

        // GET: PaymentGroups/Details/5
        public async Task<IActionResult> Details(int id)
        {
           
            var paymentGroup = await _context.PaymentGroups
                .Include(p => p.Currency)
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PaymentGroupViewModel>(paymentGroup));
        }

        // GET: PaymentGroups/Create
        public IActionResult Create()
        {
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "Id");
            ViewData["ParentId"] = new SelectList(_context.PersonGroups, "Id", "Id");
            return View();
        }

        // POST: PaymentGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,Class,CurrencyId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] PaymentGroup paymentGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "Id", paymentGroup.CurrencyId);
            ViewData["ParentId"] = new SelectList(_context.PersonGroups, "Id", "Id", paymentGroup.ParentId);
            return View(_mapper.Map<PaymentGroupViewModel>(paymentGroup));
        }

        // GET: PaymentGroups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           
            var paymentGroup = await _context.PaymentGroups.FindAsync(id);
            if (paymentGroup == null)
            {
                return NotFound();
            }
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "Id", paymentGroup.CurrencyId);
            ViewData["ParentId"] = new SelectList(_context.PersonGroups, "Id", "Id", paymentGroup.ParentId);
            return View(_mapper.Map<PaymentGroupViewModel>(paymentGroup));
        }

        // POST: PaymentGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentId,Class,CurrencyId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] PaymentGroup paymentGroup)
        {
            if (id != paymentGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentGroupExists(paymentGroup.Id))
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
            ViewData["CurrencyId"] = new SelectList(_context.Currencies, "Id", "Id", paymentGroup.CurrencyId);
            ViewData["ParentId"] = new SelectList(_context.PersonGroups, "Id", "Id", paymentGroup.ParentId);
            return View(_mapper.Map<PaymentGroupViewModel>(paymentGroup));
        }

        // GET: PaymentGroups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           
            var paymentGroup = await _context.PaymentGroups
                .Include(p => p.Currency)
                .Include(p => p.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PaymentGroupViewModel>(paymentGroup));
        }

        // POST: PaymentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentGroup = await _context.PaymentGroups.FindAsync(id);
            _context.PaymentGroups.Remove(paymentGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentGroupExists(int id)
        {
            return _context.PaymentGroups.Any(e => e.Id == id);
        }
    }
}
