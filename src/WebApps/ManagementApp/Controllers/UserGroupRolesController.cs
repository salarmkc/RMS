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
    public class UserGroupRolesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public UserGroupRolesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: UserGroupRoles
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.UserGroupRoles.Include(u => u.RoleGroup).Include(u => u.UserGroup);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<UserGroupRoleViewModel>()));
        }

        // GET: UserGroupRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroupRole = await _context.UserGroupRoles
                .Include(u => u.RoleGroup)
                .Include(u => u.UserGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGroupRole == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserGroupRoleViewModel>(userGroupRole));
        }

        // GET: UserGroupRoles/Create
        public IActionResult Create()
        {
            ViewData["RoleGroupId"] = new SelectList(_context.RoleGroups, "Id", "Name");
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name");
            return View();
        }

        // POST: UserGroupRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserGroupId,RoleGroupId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] UserGroupRole userGroupRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userGroupRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleGroupId"] = new SelectList(_context.RoleGroups, "Id", "Name", userGroupRole.RoleGroupId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", userGroupRole.UserGroupId);
            return View(_mapper.Map<UserGroupRoleViewModel>(userGroupRole));
        }

        // GET: UserGroupRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroupRole = await _context.UserGroupRoles.FindAsync(id);
            if (userGroupRole == null)
            {
                return NotFound();
            }
            ViewData["RoleGroupId"] = new SelectList(_context.RoleGroups, "Id", "Name", userGroupRole.RoleGroupId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", userGroupRole.UserGroupId);
            return View(_mapper.Map<UserGroupRoleViewModel>(userGroupRole));
        }

        // POST: UserGroupRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserGroupId,RoleGroupId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] UserGroupRole userGroupRole)
        {
            if (id != userGroupRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userGroupRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserGroupRoleExists(userGroupRole.Id))
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
            ViewData["RoleGroupId"] = new SelectList(_context.RoleGroups, "Id", "Name", userGroupRole.RoleGroupId);
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", userGroupRole.UserGroupId);
            return View(_mapper.Map<UserGroupRoleViewModel>(userGroupRole));
        }

        // GET: UserGroupRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGroupRole = await _context.UserGroupRoles
                .Include(u => u.RoleGroup)
                .Include(u => u.UserGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGroupRole == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserGroupRoleViewModel>(userGroupRole));
        }

        // POST: UserGroupRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userGroupRole = await _context.UserGroupRoles.FindAsync(id);
            _context.UserGroupRoles.Remove(userGroupRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserGroupRoleExists(int id)
        {
            return _context.UserGroupRoles.Any(e => e.Id == id);
        }
    }
}
