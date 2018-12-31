using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.Stuff
{
    public class BarcodeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نوع بارکد", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Type { get; set; }

        [Display(Name = "بارکد کالا", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]


        public string BarcodeStuff { get; set; }
        [Display(Name = "کالا", Description = "")]

        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]

        public int StuffId { get; set; }
        public Entities.Stuff Stuff { get; set; }

        [Display(Name = "بارکد پیش فرض", Description = "")]
        public bool IsDefault { get; set; }
    }
}
