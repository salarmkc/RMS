using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities.Share;

namespace ApplicationCore.ViewModel.CashDesk
{
    public class CashDeskUtilityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "صندوق", Description = "")]
        public int? CashDeskId { get; set; }
        public Entities.CashDesk CashDesk { get; set; }
        [Display(Name = "ابزارها", Description = "")]
        public int? UtilityId { get; set; }
        public Utility Utility { get; set; }
    }
}
