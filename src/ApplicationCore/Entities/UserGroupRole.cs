using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class UserGroupRole : BaseEntity
    {
        [Display(Name = "گروه کاربران", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }
        [Display(Name = "گروه نقش", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int RoleGroupId { get; set; }
        public RoleGroup RoleGroup { get; set; }
    }
}
