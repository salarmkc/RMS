using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.Stuff
{
 public   class StuffSupplierViewModel
    {
        public int Id { get; set; }

        [Display(Name = " کالا", Description = "")]
        public int StuffId { get; set; }
        public Entities.Stuff Stuff { get; set; }
        [Display(Name = "تامین کننده", Description = "")]
        public int SupplierId { get; set; }
        public Entities.Supplier Supplier { get; set; }
    }
}
