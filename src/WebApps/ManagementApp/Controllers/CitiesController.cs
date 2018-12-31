using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.Location;
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
    public class CitiesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;
        public CitiesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Cities.Include(c => c.Province);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<CityViewModel>()));
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int id)
        {
          

            var city = await _context.Cities
                .Include(c => c.Province)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CityViewModel>(city));
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "Name");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ProvinceId,Code")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "Id", city.ProvinceId);
            return View(_mapper.Map<CityViewModel>(city));
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
        

            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "Name", city.ProvinceId);
            return View(_mapper.Map<CityViewModel>(city));
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ProvinceId,Code,Id")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "Name", city.ProvinceId);
            return View(_mapper.Map<CityViewModel>(city));
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var city = await _context.Cities
                .Include(c => c.Province)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CityViewModel>(city));
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
