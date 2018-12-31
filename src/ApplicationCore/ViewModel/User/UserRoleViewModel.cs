using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.ViewModel.User
{
   public class UserRoleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نقش", Description = "")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "کاربر", Description = "")]
        public string RelativeId { get; set; }
        public ApplicationCore.Entities.User Relative { get; set; }
    }
}
