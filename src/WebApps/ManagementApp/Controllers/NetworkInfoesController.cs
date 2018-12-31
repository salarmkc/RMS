using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Share;
using ApplicationCore.ViewModel.Network;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class NetworkInfoesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public NetworkInfoesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: NetworkInfoes
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.NetworkInfos.ToListAsync(),new  List<NetworkInfoViewModel>()));
        }

        // GET: NetworkInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var networkInfo = await _context.NetworkInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (networkInfo == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<NetworkInfoViewModel>(networkInfo));
        }

        // GET: NetworkInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NetworkInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ip,Port,Mac,HostName,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] NetworkInfo networkInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(networkInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<NetworkInfoViewModel>(networkInfo));
        }

        // GET: NetworkInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var networkInfo = await _context.NetworkInfos.FindAsync(id);
            if (networkInfo == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<NetworkInfoViewModel>(networkInfo));
        }

        // POST: NetworkInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ip,Port,Mac,HostName,Id,UserId,Status,ModDateTime,ModByUserId,Comment")] NetworkInfo networkInfo)
        {
            if (id != networkInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(networkInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetworkInfoExists(networkInfo.Id))
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
            return View(_mapper.Map<NetworkInfoViewModel>(networkInfo));
        }

        // GET: NetworkInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var networkInfo = await _context.NetworkInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (networkInfo == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<NetworkInfoViewModel>(networkInfo));
        }

        // POST: NetworkInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var networkInfo = await _context.NetworkInfos.FindAsync(id);
            _context.NetworkInfos.Remove(networkInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetworkInfoExists(int id)
        {
            return _context.NetworkInfos.Any(e => e.Id == id);
        }
    }
}
