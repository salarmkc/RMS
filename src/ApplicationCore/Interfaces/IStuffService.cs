using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Enum;
using Microsoft.EntityFrameworkCore.Query;

namespace ApplicationCore.Interfaces
{
    public interface IStuffService
    {
        IQueryable<Stuff> Search(IIncludableQueryable<Stuff, StuffUnit> stuffs, int page, int recordsPerPage,
            string term, SortBy sortBy, SortOrder sortOrder, out int pageSize, out int totalItemCount);
        void Create(Stuff input);
        
    }
}
