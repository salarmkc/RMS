using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Person;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class PersonGroupsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public PersonGroupsController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PersonGroups
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.PersonGroups.ToListAsync(), new List<PersonGroupViewModel>()));
        }

        // GET: PersonGroups/Details/5
        public async Task<IActionResult> Details(int id)
        {
           

            var personGroup = await _context.PersonGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PersonGroupViewModel>(personGroup));
        }

        // GET: PersonGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LatinName,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] PersonGroup personGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<PersonGroupViewModel>(personGroup));
        }

        // GET: PersonGroups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            

            var personGroup = await _context.PersonGroups.FindAsync(id);
            if (personGroup == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<PersonGroupViewModel>(personGroup));
        }

        // POST: PersonGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LatinName,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] PersonGroup personGroup)
        {
            if (id != personGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonGroupExists(personGroup.Id))
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
            return View(_mapper.Map<PersonGroupViewModel>(personGroup));
        }

        // GET: PersonGroups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var personGroup = await _context.PersonGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PersonGroupViewModel>(personGroup));
        }

        // POST: PersonGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personGroup = await _context.PersonGroups.FindAsync(id);
            _context.PersonGroups.Remove(personGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonGroupExists(int id)
        {
            return _context.PersonGroups.Any(e => e.Id == id);
        }
    }
}
