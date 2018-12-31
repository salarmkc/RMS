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
    public class PermissionsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public PermissionsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Permissions.Include(p => p.PermissionParent);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<PermissionViewModel>()));
        }

        // GET: Permissions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var permission = await _context.Permissions
                .Include(p => p.PermissionParent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PermissionViewModel>(permission));
        }

        // GET: Permissions/Create
        public IActionResult Create()
        {
            ViewData["PermissionParentId"] = new SelectList(_context.Permissions, "Id", "Id");
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionParentId,Title,Text,Key,URL,Priority,SateIsPage,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionParentId"] = new SelectList(_context.Permissions, "Id", "Id", permission.PermissionParentId);
            return View(_mapper.Map<PermissionViewModel>(permission));
        }

        // GET: Permissions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            ViewData["PermissionParentId"] = new SelectList(_context.Permissions, "Id", "Id", permission.PermissionParentId);
            return View(_mapper.Map<PermissionViewModel>(permission));
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionParentId,Title,Text,Key,URL,Priority,SateIsPage,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Permission permission)
        {
            if (id != permission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionExists(permission.Id))
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
            ViewData["PermissionParentId"] = new SelectList(_context.Permissions, "Id", "Id", permission.PermissionParentId);
            return View(_mapper.Map<PermissionViewModel>(permission));
        }

        // GET: Permissions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var permission = await _context.Permissions
                .Include(p => p.PermissionParent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PermissionViewModel>(permission));
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionExists(int id)
        {
            return _context.Permissions.Any(e => e.Id == id);
        }
    }
}
