using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.CashDesk;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class UserCashDesksController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public UserCashDesksController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: UserCashDesks
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.UserCashDesks.Include(u => u.Branch).Include(u => u.Role);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<UserCashDeskViewModel>()));
        }

        // GET: UserCashDesks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCashDesk = await _context.UserCashDesks
                .Include(u => u.Branch)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCashDesk == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserCashDeskViewModel>(userCashDesk));
        }

        // GET: UserCashDesks/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp");
            return View();
        }

        // POST: UserCashDesks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchId,RoleId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] UserCashDesk userCashDesk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCashDesk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", userCashDesk.BranchId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp", userCashDesk.RoleId);
            return View(_mapper.Map<UserCashDeskViewModel>(userCashDesk));
        }

        // GET: UserCashDesks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCashDesk = await _context.UserCashDesks.FindAsync(id);
            if (userCashDesk == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", userCashDesk.BranchId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp", userCashDesk.RoleId);
            return View(_mapper.Map<UserCashDeskViewModel>(userCashDesk));
        }

        // POST: UserCashDesks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchId,RoleId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] UserCashDesk userCashDesk)
        {
            if (id != userCashDesk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCashDesk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCashDeskExists(userCashDesk.Id))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name", userCashDesk.BranchId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp", userCashDesk.RoleId);
            return View(_mapper.Map<UserCashDeskViewModel>(userCashDesk));
        }

        // GET: UserCashDesks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCashDesk = await _context.UserCashDesks
                .Include(u => u.Branch)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCashDesk == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserCashDeskViewModel>(userCashDesk));
        }

        // POST: UserCashDesks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userCashDesk = await _context.UserCashDesks.FindAsync(id);
            _context.UserCashDesks.Remove(userCashDesk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCashDeskExists(int id)
        {
            return _context.UserCashDesks.Any(e => e.Id == id);
        }
    }
}
