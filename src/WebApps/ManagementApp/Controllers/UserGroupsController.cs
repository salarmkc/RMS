using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.ViewModel.User;
using AutoMapper;
using Database;
using Database.Data;

namespace ManagementApp.Controllers
{
    public class UserGroupsController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;


        public UserGroupsController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: UserGroups
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map(await _context.UserGroups.ToListAsync(),new List<UserGroupViewModel>()));
        }

        // GET: UserGroups/Details/5
        public async Task<IActionResult> Details(int id)
        {
          

            var userGroup = await _context.UserGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserGroupViewModel>(userGroup));
        }

        // GET: UserGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<UserGroupViewModel>(userGroup));
        }

        // GET: UserGroups/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
         

            var userGroup = await _context.UserGroups.FindAsync(id);
            if (userGroup == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<UserGroupViewModel>(userGroup));
        }

        // POST: UserGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] UserGroup userGroup)
        {
            if (id != userGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserGroupExists(userGroup.Id))
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
            return View(_mapper.Map<UserGroupViewModel>(userGroup));
        }

        // GET: UserGroups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            

            var userGroup = await _context.UserGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGroup == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserGroupViewModel>(userGroup));
        }

        // POST: UserGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userGroup = await _context.UserGroups.FindAsync(id);
            _context.UserGroups.Remove(userGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserGroupExists(int id)
        {
            return _context.UserGroups.Any(e => e.Id == id);
        }
    }
}
