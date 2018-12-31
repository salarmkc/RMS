using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Share;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class CashDesk : BaseEntity
    {
        [Display(Name = "نام صندوق", Description = "نام صندوق")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "شبکه", Description = "")]
        

        public  int? NetworkInfoId { get; set; }

        public NetworkInfo NetworkInfo { get; set; }
        [Display(Name="شعبه", Description = "id شعبه")]
        

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Utility> Utilities { get; set; }

        public CashDesk()
        {
            Utilities=new List<Utility>();
        }
    }
}
