using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.Chart;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
      
            var rmsDbContext = _context.Companies.Include(c => c.NetworkInfo);
            return View(_mapper.Map(await rmsDbContext.ToListAsync(),new List<CompanyViewModel>()));
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CompanyViewModel>(company));
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LatinName,LegalName,StartDate,EndDate,NetworkInfoId,PhotoId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Company company)
        {
            if (ModelState.IsValid)
            {
                
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream, CancellationToken.None);
                        company.PhotoId = memoryStream.ToArray();
                    }
                }


                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", company.NetworkInfoId);
            return View(_mapper.Map<CompanyViewModel>(company));
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", company.NetworkInfoId);
            return View(_mapper.Map<CompanyViewModel>(company));
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,LatinName,LegalName,StartDate,EndDate,NetworkInfoId,PhotoId,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            ViewData["NetworkInfoId"] = new SelectList(_context.NetworkInfos, "Id", "HostName", company.NetworkInfoId);
            return View(_mapper.Map<CompanyViewModel>(company));
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .Include(c => c.NetworkInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CompanyViewModel>(company));
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
