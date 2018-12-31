using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Holding;
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
using ApplicationCore.ViewModel.Contact;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class HoldingsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public HoldingsController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Holdings
        public async Task<IActionResult> Index()
        {

            var holdings = await _context.Holdings.ToListAsync();
            List<ViewModel.HoldingViewModel> hm = new List<ViewModel.HoldingViewModel>();
            foreach (var holding in holdings)
            {
                hm.Add(new ViewModel.HoldingViewModel()
                {
                    HoldingLogo = holding.HoldingLogo,
                    HoldingName = holding.HoldingName,
                    HoldingNameEn = holding.HoldingNameEn,
                    Id = holding.Id
                });
              }

            return View(hm);
        }

        // GET: Holdings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var holding = await _context.Holdings.Include(r => r.HoldingContacts)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holding == null)
            {
                return NotFound();
            }
                
            ViewBag.ReturnUrl = Request.Headers["Referer"].ToString();
            ViewData["CitiesId"] = new SelectList(_context.Cities, "Id", "Name");
            ViewBag.Cities = await _context.Cities.ToListAsync();
            return View(_mapper.Map(holding,new HoldingViewModel()));
        }
       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddContact(int EntityRecordId,int CityId,string Tel,string Mobile,string Email,string Fax,string WebSite,string Address)
        {

            var contact=new HoldingContact()
            {
                Address = Address,
                CityId =CityId,
                 Email = Email,
                Tel = Tel,
                Fax=Fax,
                HoldingId = EntityRecordId,
                Mobile = Mobile,
                IsPrimary = false,
                WebSite = WebSite,
                
            };
            var id = EntityRecordId;
            _context.Add(contact);
             await _context.SaveChangesAsync();
            return RedirectToAction("Details", new {id = EntityRecordId});
        }
        // GET: Holdings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Holdings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModel.HoldingViewModel holding)
        {

            if (ModelState.IsValid)
            {
                var hold = new Holding();
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream, CancellationToken.None);
                        hold.HoldingLogo = memoryStream.ToArray();
                    }
                }

                hold.HoldingName = holding.HoldingName;
                hold.HoldingNameEn = holding.HoldingNameEn;

                _context.Add(hold);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(holding);
        }

        // GET: Holdings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var holding = await _context.Holdings.FindAsync(id);
            if (holding == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ViewModel.HoldingViewModel>(holding));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoldingName,HoldingNameEn,HoldingLogo,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Holding holding)
        {
            if (id != holding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(holding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoldingExists(holding.Id))
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
            return View(_mapper.Map<ViewModel.HoldingViewModel>(holding));
        }

        // GET: Holdings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var holding = await _context.Holdings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (holding == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<HoldingViewModel>(holding));
        }

        // POST: Holdings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var holding = await _context.Holdings.FindAsync(id);
            _context.Holdings.Remove(holding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoldingExists(int id)
        {
            return _context.Holdings.Any(e => e.Id == id);
        }
    }
}
