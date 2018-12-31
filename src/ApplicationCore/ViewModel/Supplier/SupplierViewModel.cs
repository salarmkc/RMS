using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.Supplier
{
  public  class SupplierViewModel
    {
        public int Id { get; set; }
        [Display(Name = "کد دستی تامین کننده", Description = "")]
        public int ManualCode { get; set; }
        [Display(Name = "ماهیت تامین کننده", Description = "")]
        public string Nature { get; set; }//وضعیت انتیتی آن بایستی مشخص گردد
        [Display(Name = "کد فعالیت تامین کننده", Description = "")]
        public int ActivityCode { get; set; }
        [Display(Name = "نام تامین کننده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        public ICollection<SupplierContact> SupplierContacts { get; set; }

        public SupplierViewModel()
        {
            SupplierContacts = new List<SupplierContact>();
        }
    }
}
