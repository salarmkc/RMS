using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.Branch
{
    public class DrawerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "کاربر انتسابی", Description = "کاربری که کشو پول بهش انتساب داده شده است")]
        public int OwnerUserId { get; set; }
        public  ApplicationCore.Entities.User OwnerUser { get; set; }
        [Display(Name = "کشو پول", Description = "نام کشو پول")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
    }
}
