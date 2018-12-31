//using ApplicationCore.Entities.Share;
//using ApplicationCore.ViewModel.Location;
//using AutoMapper;
//using Database;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ManagementApp.Controllers
//{
//    public class LocationsController : Controller
//    {
//        private readonly RmsDbContext _context;
//        private IMapper _mapper;
//        public LocationsController(RmsDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        // GET: Locations
//        public async Task<IActionResult> Index()
//        {
//            var rmsDbContext = _context.Locations.Include(l => l.City).Include(l => l.Country).Include(l => l.Province).Include(b => b.Branch);
//            return View(_mapper.Map(await rmsDbContext.ToListAsync(), new List<LocationViewModel>()));
//        }

//        // GET: Locations/Details/5
//        public async Task<IActionResult> Details(int id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var location = await _context.Locations
//                .Include(l => l.City)
//                .Include(l => l.Country)
//                .Include(l => l.Province)
//                .Include(b => b.Branch)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (location == null)
//            {
//                return NotFound();
//            }

//            return View(_mapper.Map<LocationViewModel>(location));
//        }

//        // GET: Locations/Create
//        public IActionResult Create()
//        {
//            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
//            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
//            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Name");
//            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Name");
//            return View();
//        }

//        // POST: Locations/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("CountryId,CityId,ProvinceId,BranchId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Location location)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(location);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", location.CityId);
//            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", location.CountryId);
//            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id", location.ProvinceId);
//            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", location.BranchId);
//            return View(_mapper.Map<LocationViewModel>(location));
//        }

//        // GET: Locations/Edit/5
//        public async Task<IActionResult> Edit(int id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var location = await _context.Locations.FindAsync(id);
//            if (location == null)
//            {
//                return NotFound();
//            }
//            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", location.CityId);
//            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", location.CountryId);
//            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id", location.ProvinceId);
//            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", location.BranchId);
//            return View(_mapper.Map<LocationViewModel>(location));
//        }

//        // POST: Locations/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("CountryId,CityId,ProvinceId,BranchId,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Location location)
//        {
//            if (id != location.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(location);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!LocationExists(location.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", location.CityId);
//            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", location.CountryId);
//            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Id", location.ProvinceId);
//            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", location.BranchId);
//            return View(_mapper.Map<LocationViewModel>(location));
//        }

//        // GET: Locations/Delete/5
//        public async Task<IActionResult> Delete(int id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var location = await _context.Locations
//                .Include(l => l.City)
//                .Include(l => l.Country)
//                .Include(l => l.Province)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (location == null)
//            {
//                return NotFound();
//            }

//            return View(_mapper.Map<LocationViewModel>(location));
//        }

//        // POST: Locations/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var location = await _context.Locations.FindAsync(id);
//            _context.Locations.Remove(location);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool LocationExists(int id)
//        {
//            return _context.Locations.Any(e => e.Id == id);
//        }
//    }
//}
