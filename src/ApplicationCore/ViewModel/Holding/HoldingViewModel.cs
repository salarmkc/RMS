using ApplicationCore.Entities.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.ViewModel.Contact;

namespace ApplicationCore.ViewModel.Holding
{
    public class HoldingViewModel
    {
        public virtual int Id{ get; set; }
        [Display(Name = "نام هلدینگ", Description = "نام هلدینگ")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public virtual string HoldingName { get; set; }
        [Display(Name = "نام هلدینگ", Description = "نام هلدینگ")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public virtual string HoldingNameEn { get; set; }
        [Display(Name = "لوگوی هلدینگ", Description = "")]
        public virtual byte[] HoldingLogo { get; set; }
        [Display(Name = "ارتباط", Description = "")]
        public virtual ICollection<ContactModalViewModel> HoldingContacts { get; set; }
        public HoldingViewModel()
        {
            HoldingContacts = new List<ContactModalViewModel>();
        }

        
    }
}
