using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.User;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class RolePermissionsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public RolePermissionsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: RolePermissions
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.RolePermissions.Include(r => r.Permission).Include(r => r.Role);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<RolePermissionViewModel>()));
        }

        // GET: RolePermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions
                .Include(r => r.Permission)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RolePermissionViewModel>(rolePermission));
        }

        // GET: RolePermissions/Create
        public IActionResult Create()
        {
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Title");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: RolePermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,PermissionId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] RolePermission rolePermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolePermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Title", rolePermission.PermissionId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp", rolePermission.RoleId);
            return View(_mapper.Map<RolePermissionViewModel>(rolePermission));
        }

        // GET: RolePermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions.FindAsync(id);
            if (rolePermission == null)
            {
                return NotFound();
            }
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Title", rolePermission.PermissionId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp", rolePermission.RoleId);
            return View(_mapper.Map<RolePermissionViewModel>(rolePermission));
        }

        // POST: RolePermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,PermissionId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] RolePermission rolePermission)
        {
            if (id != rolePermission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolePermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolePermissionExists(rolePermission.Id))
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
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Title", rolePermission.PermissionId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "ConcurrencyStamp", rolePermission.RoleId);
            return View(_mapper.Map<RolePermissionViewModel>(rolePermission));
        }

        // GET: RolePermissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePermission = await _context.RolePermissions
                .Include(r => r.Permission)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rolePermission == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RolePermissionViewModel>(rolePermission));
        }

        // POST: RolePermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolePermission = await _context.RolePermissions.FindAsync(id);
            _context.RolePermissions.Remove(rolePermission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolePermissionExists(int id)
        {
            return _context.RolePermissions.Any(e => e.Id == id);
        }
    }
}
