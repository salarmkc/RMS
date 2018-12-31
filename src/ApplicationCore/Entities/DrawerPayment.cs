using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class DrawerPayment:BaseEntity
    {
        [Display(Name = "کلاس روش پرداخت",Description = "گروه روش پرداخت ها")]
        public int PaymentGroupId { get; set; }
        public PaymentGroup PaymentGroup { get; set; }
        [Display(Name = "کشو", Description = "کشو اختصاص یافته")]
        public int DrawerId { get; set; }
        public Drawer Drawer { get; set; }
    }
}
