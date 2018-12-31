using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.User
{
 public  class UserGroupRoleViewModel
    {
        public int Id { get; set; }
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
