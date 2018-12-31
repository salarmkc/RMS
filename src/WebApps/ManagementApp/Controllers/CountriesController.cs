using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Static;
using ApplicationCore.ViewModel.Location;
using AutoMapper;
using Database;
using Database.Data;
using Newtonsoft.Json;

namespace ManagementApp.Controllers
{
    public class CountriesController : Controller
    {
        private readonly RmsDbContext _context;
        private readonly IMapper _mapper;
       // private readonly string _baseurl = "http://localhost:12345/";

        public CountriesController(RmsDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {

           //var empInfo = new List<Country>();

           // using (var client = new HttpClient())
           // {
           //     //Passing service base url  
           //     client.BaseAddress = new Uri(_baseurl);

           //     client.DefaultRequestHeaders.Clear();
           //     //Define request data format  
           //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           //     //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
           //     HttpResponseMessage Res = await client.GetAsync("api/countries");

           //     //Checking the response is successful or not which is sent using HttpClient  
           //     if (Res.IsSuccessStatusCode)
           //     {
           //         //Storing the response details recieved from web api   
           //         var empResponse = Res.Content.ReadAsStringAsync().Result;

           //         //Deserializing the response recieved from web api and storing into the Employee list  
           //         empInfo = JsonConvert.DeserializeObject<List<Country>>(empResponse);

           //     }
           //     //returning the employee list to view  
           //     return View(_mapper.Map(empInfo, new List<CountryViewModel>()));

                return View(_mapper.Map(await _context.Countries.ToListAsync(), new List<CountryViewModel>()));

            
        
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int id)
        {
            

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Country,CountryViewModel>(country,new CountryViewModel()));
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISO,Name,LatinName,ISO3,CountryCode")] Country country)
        {
            if (ModelState.IsValid)
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map(country, new CountryViewModel()));
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
           

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(country,new CountryViewModel()));
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISO,Name,NiceName,ISO3,CountryCode,CallingCode,Id,UserId,LogRecordId,Status,ModDateTime,ModByUserId,Comment")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
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
            return View(_mapper.Map(country, new CountryViewModel()));
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(_mapper.Map(country, new CountryViewModel()));
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
