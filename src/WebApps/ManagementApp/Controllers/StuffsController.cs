using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.Enum;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModel.Stuff;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class StuffsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStuffService _stuffService;
        private int page;
        private int pageSize;
        private int recordsPerPage;
        private int totalItemCount;
        public StuffsController(RmsDbContext context,IMapper mapper, IStuffService stuffService)
        {
            _context = context;
            _mapper = mapper;
            _stuffService = stuffService;
            
            page = 1;
            pageSize = 0;
            recordsPerPage = 50;
            totalItemCount = 0;
        }

        // GET: Stuffs
        public async Task<IActionResult> Index()
        {
            //var users = _userService.Search(page: page, recordsPerPage: recordsPerPage, term: "", sortBy: SortBy.AddDate, sortOrder: SortOrder.Desc, pageSize: out pageSize, TotalItemCount: out totalItemCount);
            
            var stuffs = _stuffService.Search(_context.Stuffs.Include(s => s.Brand).Include(s => s.StuffGroup).Include(s => s.StuffUnit), page, recordsPerPage, "", SortBy.ManualCode, SortOrder.Asc,
                pageSize: out pageSize, totalItemCount: out totalItemCount);
            

            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = totalItemCount;
            var rmsDbContext = _context.Stuffs.Include(s => s.Brand).Include(s => s.StuffGroup).Include(s => s.StuffUnit);
            return View(_mapper.Map(await stuffs.ToListAsync(),new List<StuffViewModel>()));
        }
        [HttpGet]
        public ActionResult Search(int page = 1, string term = "", SortBy sortBy = SortBy.ManualCode, SortOrder sortOrder = SortOrder.Desc)
        {
            System.Threading.Thread.Sleep(700);


            var users = _stuffService.Search(_context.Stuffs.Include(s => s.Brand).Include(s => s.StuffGroup).Include(s => s.StuffUnit), page: page, recordsPerPage: recordsPerPage, term: term, sortBy: sortBy, sortOrder: sortOrder, pageSize: out pageSize, totalItemCount: out totalItemCount);

            #region ViewBags


            ViewBag.PageSize = pageSize;
            ViewBag.CurrentPage = page;
            ViewBag.TotalItemCount = totalItemCount;


            #endregion
            return PartialView("_StuffList");
           // return PartialView("_UsersList", stuffs);
        }

        // GET: Stuffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs
                .Include(s => s.Brand)
                .Include(s => s.StuffGroup)
                .Include(s => s.StuffUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffViewModel>(stuff));
        }

        // GET: Stuffs/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["StuffGroupId"] = new SelectList(_context.StuffGroups, "Id", "GroupName");
            ViewData["StuffUnitId"] = new SelectList(_context.Set<StuffUnit>(), "Id", "Name");
            return View();
        }

        // POST: Stuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManualCode,Name,LatinName,ShortName,StuffGroupId,StuffUnitId,WebUrl,BrandId,BarcodeId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", stuff.BrandId);
            ViewData["StuffGroupId"] = new SelectList(_context.StuffGroups, "Id", "GroupName", stuff.StuffGroupId);
            ViewData["StuffUnitId"] = new SelectList(_context.Set<StuffUnit>(), "Id", "Name", stuff.StuffUnitId);
            return View(_mapper.Map<StuffViewModel>(stuff));
        }

        // GET: Stuffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs.FindAsync(id);
            if (stuff == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", stuff.BrandId);
            ViewData["StuffGroupId"] = new SelectList(_context.StuffGroups, "Id", "GroupName", stuff.StuffGroupId);
            ViewData["StuffUnitId"] = new SelectList(_context.Set<StuffUnit>(), "Id", "Name", stuff.StuffUnitId);
            return View(_mapper.Map<StuffViewModel>(stuff));
        }

        // POST: Stuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManualCode,Name,LatinName,ShortName,StuffGroupId,StuffUnitId,WebUrl,BrandId,BarcodeId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Stuff stuff)
        {
            if (id != stuff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffExists(stuff.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", stuff.BrandId);
            ViewData["StuffGroupId"] = new SelectList(_context.StuffGroups, "Id", "GroupName", stuff.StuffGroupId);
            ViewData["StuffUnitId"] = new SelectList(_context.Set<StuffUnit>(), "Id", "Name", stuff.StuffUnitId);
            return View(_mapper.Map<StuffViewModel>(stuff));
        }

        // GET: Stuffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuffs
                .Include(s => s.Brand)
                .Include(s => s.StuffGroup)
                .Include(s => s.StuffUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<StuffViewModel>(stuff));
        }

        // POST: Stuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stuff = await _context.Stuffs.FindAsync(id);
            _context.Stuffs.Remove(stuff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffExists(int id)
        {
            return _context.Stuffs.Any(e => e.Id == id);
        }
    }
}
