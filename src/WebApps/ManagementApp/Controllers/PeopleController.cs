using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Person;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public PeopleController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Persons.Include(p => p.PersonGroup);
          
            return View(_mapper.Map(await rmsDbContext.ToListAsync(), new List<PersonViewModel>()));
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.PersonGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PersonViewModel>(person));
        }

        // GET: People/Create
        public IActionResult Create()
        {
            ViewData["PersonGroupId"] = new SelectList(_context.PersonGroups, "Id", "LatinName");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonGroupId,FirstName,LastName,BirthDate,Gender,PhotoId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Person person)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream, CancellationToken.None);
                        person.PhotoId = memoryStream.ToArray();
                    }
                }

                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonGroupId"] = new SelectList(_context.PersonGroups, "Id", "LatinName", person.PersonGroupId);
            return View(_mapper.Map<PersonViewModel>(person));
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["PersonGroupId"] = new SelectList(_context.PersonGroups, "Id", "LatinName", person.PersonGroupId);
            return View(_mapper.Map<PersonViewModel>(person));
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonGroupId,FirstName,LastName,BirthDate,Gender,PhotoId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            ViewData["PersonGroupId"] = new SelectList(_context.PersonGroups, "Id", "LatinName", person.PersonGroupId);
            return View(_mapper.Map<PersonViewModel>(person));
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.PersonGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PersonViewModel>(person));
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
