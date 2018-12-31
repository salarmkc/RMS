using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities.Share;

namespace ApplicationCore.ViewModel.CashDesk
{
   public class CashDeskViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام صندوق", Description = "نام صندوق")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "شبکه", Description = "")]


        public int? NetworkInfoId { get; set; }

        public NetworkInfo NetworkInfo { get; set; }
        [Display(Name = "شعبه", Description = "id شعبه")]


        public int BranchId { get; set; }
        public Entities.Branch Branch { get; set; }
        public ICollection<Utility> Utilities { get; set; }

        public CashDeskViewModel()
        {
            Utilities = new List<Utility>();
        }
    }
}
