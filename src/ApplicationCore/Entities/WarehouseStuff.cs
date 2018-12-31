using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class WarehouseStuff:BaseEntity
    {
        [Display(Name = "کالا", Description = "")]
        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }
        [Display(Name = "انبار", Description = "")]
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
