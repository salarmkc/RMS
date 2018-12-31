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
    public class StuffGroupsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public StuffGroupsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: StuffGroups
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map( await _context.StuffGroups.ToListAsync(),new List<StuffGroupViewModel>()));
        }

        // GET: StuffGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffGroup = await _context.StuffGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuffGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffGroupViewModel>(stuffGroup));
        }

        // GET: StuffGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StuffGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManualCode,GroupName,Photo,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] StuffGroup stuffGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuffGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<StuffGroupViewModel>(stuffGroup));
        }

        // GET: StuffGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffGroup = await _context.StuffGroups.FindAsync(id);
            if (stuffGroup == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<StuffGroupViewModel>(stuffGroup));
        }

        // POST: StuffGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManualCode,GroupName,Photo,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] StuffGroup stuffGroup)
        {
            if (id != stuffGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuffGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffGroupExists(stuffGroup.Id))
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
            return View(_mapper.Map<StuffGroupViewModel>(stuffGroup));
        }

        // GET: StuffGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuffGroup = await _context.StuffGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuffGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffGroupViewModel>(stuffGroup));
        }

        // POST: StuffGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stuffGroup = await _context.StuffGroups.FindAsync(id);
            _context.StuffGroups.Remove(stuffGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffGroupExists(int id)
        {
            return _context.StuffGroups.Any(e => e.Id == id);
        }
    }
}
