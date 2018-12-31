using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Database;
using AutoMapper;
using ApplicationCore.ViewModel.BaseInfo;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class MeasuresController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public MeasuresController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Measures
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.Measures.ToListAsync(),new List<MeasureViewModel>()));
        }

        // GET: Measures/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var measure = await _context.Measures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measure == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<MeasureViewModel>(measure));
        }

        // GET: Measures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Measures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("X,Y,Area,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<MeasureViewModel>(measure));
        }

        // GET: Measures/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
          
            var measure = await _context.Measures.FindAsync(id);
            if (measure == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<MeasureViewModel>(measure));
        }

        // POST: Measures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("X,Y,Area,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Measure measure)
        {
            if (id != measure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasureExists(measure.Id))
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
            return View(_mapper.Map<MeasureViewModel>(measure));
        }

        // GET: Measures/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
           
            var measure = await _context.Measures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measure == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<MeasureViewModel>(measure));
        }

        // POST: Measures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var measure = await _context.Measures.FindAsync(id);
            _context.Measures.Remove(measure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasureExists(int id)
        {
            return _context.Measures.Any(e => e.Id == id);
        }
    }
}
