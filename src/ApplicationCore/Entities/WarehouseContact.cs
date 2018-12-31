using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities
{
    public class WarehouseContact:BaseContact
    {
        public int WarehouseId { get; set; }
        public ApplicationCore.Entities.Warehouse Warehouse { get; set; }
    }
}
