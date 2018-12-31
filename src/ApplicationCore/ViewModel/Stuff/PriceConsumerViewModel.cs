using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.Stuff
{
  public  class PriceConsumerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "کد کالا", Description = "")]
        public int StuffId { get; set; }
        public Entities.Stuff Stuff { get; set; }
        [Display(Name = "قیمت مصرف کننده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }
    }
}
