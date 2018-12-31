using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Menu;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class ManagementAppMenusController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public ManagementAppMenusController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: ManagementAppMenus
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.ManagementAppMenus.Include(m => m.AppMenu);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<ManagementAppMenuViewModel>()));
        }

        // GET: ManagementAppMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementAppMenu = await _context.ManagementAppMenus
                .Include(m => m.AppMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managementAppMenu == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ManagementAppMenuViewModel>(managementAppMenu));
        }

        // GET: ManagementAppMenus/Create
        public IActionResult Create()
        {
            ViewData["AppMenuId"] = new SelectList(_context.ManagementAppMenus, "Id", "MenuClass");
            return View();
        }

        // POST: ManagementAppMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppMenuId,MenuName,MenuClass,MenuUrl,Priority")] ManagementAppMenu managementAppMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(managementAppMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppMenuId"] = new SelectList(_context.ManagementAppMenus, "Id", "MenuClass", managementAppMenu.AppMenuId);
            return View(_mapper.Map<ManagementAppMenuViewModel>(managementAppMenu));
        }

        // GET: ManagementAppMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementAppMenu = await _context.ManagementAppMenus.FindAsync(id);
            if (managementAppMenu == null)
            {
                return NotFound();
            }
            ViewData["AppMenuId"] = new SelectList(_context.ManagementAppMenus, "Id", "MenuClass", managementAppMenu.AppMenuId);
            return View(_mapper.Map<ManagementAppMenuViewModel>(managementAppMenu));
        }

        // POST: ManagementAppMenus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppMenuId,MenuName,MenuClass,MenuUrl,Priority")] ManagementAppMenu managementAppMenu)
        {
            if (id != managementAppMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managementAppMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagementAppMenuExists(managementAppMenu.Id))
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
            ViewData["AppMenuId"] = new SelectList(_context.ManagementAppMenus, "Id", "MenuClass", managementAppMenu.AppMenuId);
            return View(_mapper.Map<ManagementAppMenuViewModel>(managementAppMenu));
        }

        // GET: ManagementAppMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementAppMenu = await _context.ManagementAppMenus
                .Include(m => m.AppMenu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managementAppMenu == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ManagementAppMenuViewModel>(managementAppMenu));
        }

        // POST: ManagementAppMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managementAppMenu = await _context.ManagementAppMenus.FindAsync(id);
            _context.ManagementAppMenus.Remove(managementAppMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagementAppMenuExists(int id)
        {
            return _context.ManagementAppMenus.Any(e => e.Id == id);
        }
    }
}
