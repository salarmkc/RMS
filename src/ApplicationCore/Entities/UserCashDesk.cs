using ApplicationCore.Abstract;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class UserCashDesk : BaseEntity
    {
        [Display(Name = "شعبه", Description = "")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        [Display(Name = "نقش", Description = "")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
