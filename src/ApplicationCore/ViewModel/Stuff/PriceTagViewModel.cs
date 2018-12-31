using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities.Static;

namespace ApplicationCore.ViewModel.Stuff
{
   public class PriceTagViewModel
    {
        public int Id { get; set; }
        [Display(Name = "شهر", Description = "")]

        public int CityId { get; set; }
        public City City { get; set; }
        [Display(Name = "شعبه", Description = "")]
        public int BranchId { get; set; }
        public Entities.Branch Branch { get; set; }

        [Display(Name = "کد کالا", Description = "")]


        public int StuffId { get; set; }
        public Entities.Stuff Stuff { get; set; }
        [Display(Name = "قیمت مصرف کننده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }
    }
}
