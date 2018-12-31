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
    public class DrawerPaymentsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public DrawerPaymentsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: DrawerPayments
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.DrawerPayments.Include(d => d.Drawer).Include(d => d.PaymentGroup);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<DrawerPaymentViewModel>()));
        }

        // GET: DrawerPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawerPayment = await _context.DrawerPayments
                .Include(d => d.Drawer)
                .Include(d => d.PaymentGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawerPayment == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<DrawerPaymentViewModel>(drawerPayment));
            
        }

        // GET: DrawerPayments/Create
        public IActionResult Create()
        {
            ViewData["DrawerId"] = new SelectList(_context.Drawers, "Id", "Name");
            ViewData["PaymentGroupId"] = new SelectList(_context.PaymentGroups, "Id", "Class");
            return View();
        }

        // POST: DrawerPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentGroupId,DrawerId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] DrawerPayment drawerPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drawerPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrawerId"] = new SelectList(_context.Drawers, "Id", "Name", drawerPayment.DrawerId);
            ViewData["PaymentGroupId"] = new SelectList(_context.PaymentGroups, "Id", "Class", drawerPayment.PaymentGroupId);
            return View(_mapper.Map<DrawerPaymentViewModel>(drawerPayment));
        }

        // GET: DrawerPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawerPayment = await _context.DrawerPayments.FindAsync(id);
            if (drawerPayment == null)
            {
                return NotFound();
            }
            ViewData["DrawerId"] = new SelectList(_context.Drawers, "Id", "Name", drawerPayment.DrawerId);
            ViewData["PaymentGroupId"] = new SelectList(_context.PaymentGroups, "Id", "Class", drawerPayment.PaymentGroupId);
            return View(_mapper.Map<DrawerPaymentViewModel>(drawerPayment));
        }

        // POST: DrawerPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentGroupId,DrawerId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] DrawerPayment drawerPayment)
        {
            if (id != drawerPayment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drawerPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawerPaymentExists(drawerPayment.Id))
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
            ViewData["DrawerId"] = new SelectList(_context.Drawers, "Id", "Name", drawerPayment.DrawerId);
            ViewData["PaymentGroupId"] = new SelectList(_context.PaymentGroups, "Id", "Class", drawerPayment.PaymentGroupId);
            return View(_mapper.Map<DrawerPaymentViewModel>(drawerPayment));
        }

        // GET: DrawerPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drawerPayment = await _context.DrawerPayments
                .Include(d => d.Drawer)
                .Include(d => d.PaymentGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawerPayment == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<DrawerPaymentViewModel>(drawerPayment));
        }

        // POST: DrawerPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drawerPayment = await _context.DrawerPayments.FindAsync(id);
            _context.DrawerPayments.Remove(drawerPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrawerPaymentExists(int id)
        {
            return _context.DrawerPayments.Any(e => e.Id == id);
        }
    }
}
