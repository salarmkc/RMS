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
    public class ProvincesController : Controller
    {
        private readonly RmsDbContext _context;
        private IMapper _mapper;
        public ProvincesController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Provinces
        public async Task<IActionResult> Index()
        {
            var provinces = _context.Provinces.Include(p => p.Country);
           
            //Dictionary<string, string> dictionary = _context.Countries
            //    .Select(x => new KeyValuePair<string, string>(x.Id, x.Name))
            //    .ToDictionary(x => x.Key, x => x.Value);

            //ViewBag.Countries = dictionary;
            var mapper = _mapper.Map(await provinces.ToListAsync(), new List<ProvinceViewModel>());
            return View(mapper);
        }

        // GET: Provinces/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var province = await _context.Provinces
                .Include(p => p.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProvinceViewModel>(province));
        }

        // GET: Provinces/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Provinces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,CountryId,Code")] Province province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", province.CountryId);
            return View(_mapper.Map<ProvinceViewModel>(province));
        }

        // GET: Provinces/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
          

            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", province.CountryId);
            return View(_mapper.Map<ProvinceViewModel>(province));
        }

        // POST: Provinces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,CountryId,Code,Id")] Province province)
        {
            if (id != province.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(province);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinceExists(province.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", province.CountryId);
            return View(_mapper.Map<ProvinceViewModel>(province));
        }

        // GET: Provinces/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var province = await _context.Provinces
                .Include(p => p.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProvinceViewModel>(province));
        }

        // POST: Provinces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var province = await _context.Provinces.FindAsync(id);
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinceExists(int id)
        {
            return _context.Provinces.Any(e => e.Id == id);
        }
    }
}
