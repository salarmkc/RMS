using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities
{
    public class RolePermission:BaseEntity
    {
        
        [Display(Name = "نقش", Description = "")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Display(Name = "دسترسی", Description = "")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }


    }
}
