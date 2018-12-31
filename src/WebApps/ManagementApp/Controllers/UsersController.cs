using ApplicationCore.Entities;
using ApplicationCore.ViewModel.User;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagementApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(RmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var rmsDbContext = _context.Users.Include(b => b.UserGroup);
            var mapper = _mapper.Map(await rmsDbContext.ToListAsync(), new List<UserViewModel>());
            return View(mapper);

            //  return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var user = await _context.Users.Include(u=>u.UserGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserViewModel>(user));
        }

        // GET: Users/Create
        public IActionResult Create()
        {

            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserGroupId,UserName,Password,EmailConfirmed,TwoFactorEnabled,AccessFailedCount,PhoneNumberCount,SecurityStamp,ConcurrencyStamp,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Id", user.UserGroupId);
            return View(_mapper.Map<UserViewModel>(user));
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", user.UserGroupId);
            return View(_mapper.Map<UserViewModel>(user));
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserGroupId,UserName,Password,EmailConfirmed,TwoFactorEnabled,AccessFailedCount,PhoneNumberCount,SecurityStamp,ConcurrencyStamp,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["UserGroupId"] = new SelectList(_context.UserGroups, "Id", "Name", user.UserGroupId);
            return View(_mapper.Map<UserViewModel>(user));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user= await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserViewModel>(user));
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
