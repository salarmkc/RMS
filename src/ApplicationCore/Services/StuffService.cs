using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Enum;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Query;

namespace ApplicationCore.Services
{
    public class StuffService:IStuffService

    {
        private readonly List<Stuff> _stuffs;
       
        public StuffService()
        {
            _stuffs= new List<Stuff>();
        }

        
        public IQueryable<Stuff> Search(IIncludableQueryable<Stuff, StuffUnit> stuffs, int page, int recordsPerPage,
            string term, SortBy sortBy, SortOrder sortOrder, out int pageSize,
            out int totalItemCount)
        {

            IQueryable<Stuff> queryable = stuffs;


            #region بر اساس متن



            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(c => c.ManualCode == int.Parse(term) || c.Name.Contains(term));

            }



            #endregion

            #region مرتب سازی



            switch (sortBy)
            {
                case SortBy.ManualCode:
                    queryable = sortOrder == SortOrder.Asc ? queryable.OrderBy(u => u.ManualCode) : queryable.OrderByDescending(u => u.ManualCode);
                    break;
                case SortBy.DisplayName:
                    queryable = sortOrder == SortOrder.Asc ? queryable.OrderBy(u => u.Name).ThenBy(u => u.ShortName) : queryable.OrderByDescending(u => u.Name).ThenByDescending(u => u.ShortName);
                    break;
                default:
                    break;
            }




            #endregion

            #region دریافت تعداد کل صفحات

            totalItemCount = queryable.Count();
            pageSize = (int)Math.Ceiling((double)totalItemCount / recordsPerPage);

            page = page > pageSize || page < 1 ? 1 : page;

            #endregion

            #region دریافت تعداد رکوردهای مورد تیاز


            var skiped = (page - 1) * recordsPerPage;
            queryable = queryable.Skip(skiped).Take(recordsPerPage);


            #endregion



            return queryable.Select(u => new Stuff()
            {
                Id = u.Id,
                ManualCode = u.ManualCode,
                Name = u.Name,
                LatinName =u.LatinName,
                StuffUnit = u.StuffUnit,
                StuffUnitId = u.StuffUnitId,
                StuffGroup = u.StuffGroup,
                StuffGroupId = u.StuffGroupId
            });
        }

        public void Create(Stuff input)
        {
            
        }
    }
}
