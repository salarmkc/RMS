using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Branch;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class DrawersController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;
        
        public DrawersController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Drawers
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Drawers.Include(d => d.OwnerUser);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(), new List<DrawerViewModel>()));
        }

        // GET: Drawers/Details/5
        public async Task<IActionResult> Details(int id)
        {
           

            var drawer = await _context.Drawers
                .Include(d => d.OwnerUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<DrawerViewModel>(drawer));
        }

        // GET: Drawers/Create
        public IActionResult Create()
        {
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Drawers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerUserId,Name,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Drawer drawer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drawer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "UserName", drawer.OwnerUserId);
            return View(_mapper.Map<DrawerViewModel>(drawer));
        }

        // GET: Drawers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
          

            var drawer = await _context.Drawers.FindAsync(id);
            if (drawer == null)
            {
                return NotFound();
            }
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "UserName", drawer.OwnerUserId);
            return View(_mapper.Map<DrawerViewModel>(drawer));
        }

        // POST: Drawers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnerUserId,Name,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Drawer drawer)
        {
            if (id != drawer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drawer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrawerExists(drawer.Id))
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
            ViewData["OwnerUserId"] = new SelectList(_context.Users, "Id", "UserName", drawer.OwnerUserId);
            return View(_mapper.Map<DrawerViewModel>(drawer));
        }

        // GET: Drawers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var drawer = await _context.Drawers
                .Include(d => d.OwnerUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drawer == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<DrawerViewModel>(drawer));
        }

        // POST: Drawers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drawer = await _context.Drawers.FindAsync(id);
            _context.Drawers.Remove(drawer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrawerExists(int id)
        {
            return _context.Drawers.Any(e => e.Id == id);
        }
    }
}
