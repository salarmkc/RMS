using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.Stuff
{
  public  class StuffGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "کد دستی گروه کالا", Description = "")]
        public int ManualCode { get; set; }
        [Display(Name = "نام گروه", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string GroupName { get; set; }
        [Display(Name = "تصویر گروه", Description = "")]
        public string Photo { get; set; }
    }
}
