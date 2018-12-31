using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class UserRole : BaseEntity
    {
        [Display(Name = "نقش", Description = "")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "کاربر", Description = "")]
        public string RelativeId { get; set; }
        public User Relative { get; set; }
    }
}
