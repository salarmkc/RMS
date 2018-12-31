using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.User
{
  public  class RolePermissionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نقش", Description = "")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "دسترسی", Description = "")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
