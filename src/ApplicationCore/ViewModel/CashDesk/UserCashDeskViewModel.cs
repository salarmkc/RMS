
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.CashDesk
{
    public class UserCashDeskViewModel
    {
        public int Id { get; set; }
        [Display(Name = "شعبه", Description = "")]
        public int BranchId { get; set; }
        public Entities.Branch Branch { get; set; }
        [Display(Name = "نقش", Description = "")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
