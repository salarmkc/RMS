using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.Stuff
{
    public class WarehouseStuffViewModel
    {
        public int Id { get; set; }
        [Display(Name = "کالا", Description = "")]
        public int StuffId { get; set; }
        public Entities.Stuff Stuff { get; set; }
        [Display(Name = "انبار", Description = "")]
        public int WarehouseId { get; set; }
        public Entities.Warehouse Warehouse { get; set; }
    }
}
