using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Share;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class CashDeskUtility : BaseEntity
    {
        [Display(Name = "صندوق", Description = "")]
        public int? CashDeskId { get; set; }
        public CashDesk CashDesk { get; set; }
        [Display(Name = "ابزارها", Description = "")]
        public  int? UtilityId { get; set; }
        public Utility Utility { get; set; }
    }
}
