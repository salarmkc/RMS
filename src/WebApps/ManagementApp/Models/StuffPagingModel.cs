using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Models
{
    public class StuffPagingModel:PageModel
    {
      
      

        //public async Task OnGetAsync(string sortOrder,
        //    string currentFilter, string searchString, int? pageIndex)
        //{
        //    CurrentSort = sortOrder;
        //    NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    DateSort = sortOrder == "Date" ? "date_desc" : "Date";
        //    if (searchString != null)
        //    {
        //        pageIndex = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    CurrentFilter = searchString;

        //    IQueryable<Stuff> stuffs = _context.Stuffs.Include(w => w.Brand).Include(w => w.StuffGroup).Include(e => e.StuffUnit);

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        stuffs = stuffs.Where(s =>s.Name.Contains(searchString)
        //                                         || s.LatinName.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            stuffs = stuffs.OrderByDescending(s => s.Name);
        //            break;
        //        case "Date":
        //            stuffs = stuffs.OrderBy(s => s.LatinName);
        //            break;
        //        case "date_desc":
        //            stuffs = stuffs.OrderByDescending(s => s.LatinName);
        //            break;
        //        default:
        //            stuffs = stuffs.OrderBy(s => s.Name);
        //            break;
        //    }


        //    IQueryable<StuffViewModel> aa = mapper.Map(await stuffs.ToListAsync(), new List<StuffViewModel>()).AsQueryable();
        //    var sss = await PaginatedList<StuffViewModel>.CreateAsync(
        //        aa.AsNoTracking(), pageIndex ?? 1, pageSize);
        //    int pageSize = 3;

        //}
    }
}
