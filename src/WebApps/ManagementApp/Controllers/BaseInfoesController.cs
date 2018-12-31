using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.BaseInfo;
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
    public class BaseInfoesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public BaseInfoesController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        // GET: BaseInfoes
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.BaseInfos.Include(b => b.BaseInfoGroup);
            var mapper = _mapper.Map(await rmsDbContext.ToListAsync(), new List<BaseInfoViewModel>());
            return View(mapper);
        }

        // GET: BaseInfoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var baseInfo = await _context.BaseInfos
                .Include(b => b.BaseInfoGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseInfo == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BaseInfoViewModel>(baseInfo));
        }

        // GET: BaseInfoes/Create
        public IActionResult Create()
        {
            ViewData["BaseInfoGroupId"] = new SelectList(_context.BaseInfoGroups, "Id", "BaseInfoGroupName");
            return View();
        }

        // POST: BaseInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseInfoGroupId,Name,LatinName,Value,Id")] BaseInfo baseInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseInfoGroupId"] = new SelectList(_context.BaseInfoGroups, "Id", "Id", baseInfo.BaseInfoGroupId);
            return View(_mapper.Map<BaseInfoViewModel>(baseInfo));
        }

        // GET: BaseInfoes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var baseInfo = await _context.BaseInfos.FindAsync(id);
            if (baseInfo == null)
            {
                return NotFound();
            }
            ViewData["BaseInfoGroupId"] = new SelectList(_context.BaseInfoGroups, "Id", "BaseInfoGroupName", baseInfo.BaseInfoGroupId);
            return View(_mapper.Map<BaseInfoViewModel>(baseInfo));
        }

        // POST: BaseInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaseInfoGroupId,Name,LatinName,Value,Id")] BaseInfo baseInfo)
        {
            if (id != baseInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseInfoExists(baseInfo.Id))
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
            ViewData["BaseInfoGroupId"] = new SelectList(_context.BaseInfoGroups, "Id", "Id", baseInfo.BaseInfoGroupId);
            return View(_mapper.Map<BaseInfoViewModel>(baseInfo));
        }

        // GET: BaseInfoes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var baseInfo = await _context.BaseInfos
                .Include(b => b.BaseInfoGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseInfo == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BaseInfoViewModel>(baseInfo));
        }

        // POST: BaseInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseInfo = await _context.BaseInfos.FindAsync(id);
            _context.BaseInfos.Remove(baseInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseInfoExists(int id)
        {
            return _context.BaseInfos.Any(e => e.Id == id);
        }
    }
}
