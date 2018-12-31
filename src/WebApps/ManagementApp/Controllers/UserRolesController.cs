using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Database;
using AutoMapper;
using ApplicationCore.ViewModel.User;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public UserRolesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: UserRoles
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.UserRoles.Include(u => u.Relative).Include(u => u.Role);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<UserRoleViewModel>()));
        }

        // GET: UserRoles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var userRole = await _context.UserRoles
                .Include(u => u.Relative)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserRoleViewModel>(userRole));
        }

        // GET: UserRoles/Create
        public IActionResult Create()
        {
            ViewData["RelativeId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RelativeId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelativeId"] = new SelectList(_context.Users, "Id", "UserName", userRole.RelativeId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", userRole.RoleId);
            return View(_mapper.Map<UserRoleViewModel>(userRole));
        }

        // GET: UserRoles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null)
            {
                return NotFound();
            }
            ViewData["RelativeId"] = new SelectList(_context.Users, "Id", "UserName", userRole.RelativeId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", userRole.RoleId);
            return View(_mapper.Map<UserRoleViewModel>(userRole));
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RelativeId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] UserRole userRole)
        {
            if (id != userRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userRole.Id))
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
            ViewData["RelativeId"] = new SelectList(_context.Users, "Id", "UserName", userRole.RelativeId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", userRole.RoleId);
            return View(_mapper.Map<UserRoleViewModel>(userRole));
        }

        // GET: UserRoles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var userRole = await _context.UserRoles
                .Include(u => u.Relative)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserRoleViewModel>(userRole));
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userRole = await _context.UserRoles.FindAsync(id);
            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRoleExists(int id)
        {
            return _context.UserRoles.Any(e => e.Id == id);
        }
    }
}
