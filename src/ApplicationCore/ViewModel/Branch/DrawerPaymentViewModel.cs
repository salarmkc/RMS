using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.Branch
{
  public  class DrawerPaymentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "کلاس روش پرداخت", Description = "گروه روش پرداخت ها")]
        public int PaymentGroupId { get; set; }
        public PaymentGroup PaymentGroup { get; set; }
        [Display(Name = "کشو", Description = "کشو اختصاص یافته")]
        public int DrawerId { get; set; }
        public Drawer Drawer { get; set; }
    }
}
