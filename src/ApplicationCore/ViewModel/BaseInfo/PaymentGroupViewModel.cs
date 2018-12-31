using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.BaseInfo
{
   public  class PaymentGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "شاخه اصلی", Description = "")]

        public int ParentId { get; set; }
        public PersonGroup Parent { get; set; }
        [Display(Name = "نوع روش پرداخت", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Class { get; set; }
        [Display(Name = "ارز", Description = "")]
        public int CurrencyId { get; set; }
        public Entities.Static.Currency Currency { get; set; }
    }
}
