using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities.Static;

namespace ApplicationCore.ViewModel.Contact
{
   public  class ContactModalViewModel
    {
        public  int Id { get; set; }
        
        [Display(Name = "شماره ثابت", Description = "")]
        [Required]
        public string Tel { get; set; }
        [Display(Name = "شماره همراه", Description = "")]
        public string Mobile { get; set; }
        [Display(Name = "ایمیل", Description = "")]
        [EmailAddress]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Email { get; set; }
        [Display(Name = "شماره فکس", Description = "")]
        public string Fax { get; set; }
        [Display(Name = "آدرس", Description = "")]
        public string Address { get; set; }
        [Display(Name = "وب سایت", Description = "")]

        public string WebSite { get; set; }
        [Display(Name = "پیش فرض", Description = "")]

        public bool IsPrimary { get; set; }
      
        [DisplayName("شهر")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public int CityId { get; set; }
    }
}
