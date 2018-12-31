using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.BaseInfo;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class BaseInfoGroupsController : Controller
    {
        private readonly RmsDbContext _context;
        private IMapper _mapper;


        public BaseInfoGroupsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: BaseInfoGroups
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.BaseInfoGroups.ToListAsync(),new List<BaseInfoGroupViewModel>()));
        }

        // GET: BaseInfoGroups/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            var baseInfoGroup = await _context.BaseInfoGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseInfoGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BaseInfoGroupViewModel>( baseInfoGroup));
        }

        // GET: BaseInfoGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseInfoGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseInfoGroupName,BaseInfoGroupText,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] BaseInfoGroup baseInfoGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseInfoGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<BaseInfoGroupViewModel>(baseInfoGroup));
        }

        // GET: BaseInfoGroups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            

            var baseInfoGroup = await _context.BaseInfoGroups.FindAsync(id);
            if (baseInfoGroup == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<BaseInfoGroupViewModel>(baseInfoGroup));
        }

        // POST: BaseInfoGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaseInfoGroupName,BaseInfoGroupText,Id")] BaseInfoGroup baseInfoGroup)
        {
            if (id != baseInfoGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseInfoGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseInfoGroupExists(baseInfoGroup.Id))
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
            return View(_mapper.Map<BaseInfoGroupViewModel>(baseInfoGroup));
        }

        // GET: BaseInfoGroups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           

            var baseInfoGroup = await _context.BaseInfoGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseInfoGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<BaseInfoGroupViewModel>(baseInfoGroup));
        }

        // POST: BaseInfoGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseInfoGroup = await _context.BaseInfoGroups.FindAsync(id);
            _context.BaseInfoGroups.Remove(baseInfoGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseInfoGroupExists(int id)
        {
            return _context.BaseInfoGroups.Any(e => e.Id == id);
        }
    }
}
