using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.Menu
{
  public  class ManagementAppMenuViewModel
    {
        public int Id { get; set; }
        public int? AppMenuId { get; set; }
        public ManagementAppMenu AppMenu { get; set; }

        [Display(Name = "عنوان منو", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string MenuName { get; set; }

        [Display(Name = "کلاس منو", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string MenuClass { get; set; }

        [Display(Name = "آدرس منو", Description = "")]
        public string MenuUrl { get; set; }
        [Display(Name = "اولویت نمایش منو", Description = "")]
        public ushort Priority { get; set; }
    }
}
