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
    public class RoleGroupsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public RoleGroupsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: RoleGroups
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.RoleGroups.ToListAsync(),new List<RoleGroupViewModel>()));
        }

        // GET: RoleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleGroup = await _context.RoleGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RoleGroupViewModel>(roleGroup));
        }

        // GET: RoleGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LatinName,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] RoleGroup roleGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<RoleGroupViewModel>(roleGroup));
        }

        // GET: RoleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleGroup = await _context.RoleGroups.FindAsync(id);
            if (roleGroup == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<RoleGroupViewModel>(roleGroup));
        }

        // POST: RoleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LatinName,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] RoleGroup roleGroup)
        {
            if (id != roleGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleGroupExists(roleGroup.Id))
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
            return View(_mapper.Map<RoleGroupViewModel>(roleGroup));
        }

        // GET: RoleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleGroup = await _context.RoleGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<RoleGroupViewModel>(roleGroup));
        }

        // POST: RoleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleGroup = await _context.RoleGroups.FindAsync(id);
            _context.RoleGroups.Remove(roleGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleGroupExists(int id)
        {
            return _context.RoleGroups.Any(e => e.Id == id);
        }
    }
}
