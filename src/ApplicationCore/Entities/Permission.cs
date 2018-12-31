using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities
{
    [Table("Permission")]
    public class Permission : BaseEntity
    {
        [Display(Name = "شاخه پدر", Description = "")]
        public int? PermissionParentId { get; set; }
        public Permission PermissionParent { get; set; }
        //[InverseProperty("PermissionParent")]
        //public List<Permission> PermissionChilds { get; set; }
        [Display(Name = "عنوان دسترسی", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات کامل دسترسی", Description = "")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Text { get; set; }

        [Display(Name = "کلید دسترسی", Description = "")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Key { get; set; }

        [Display(Name = "آدرس دسترسی", Description = "")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Url { get; set; }

        [Display(Name = "اولویت نمایش در لیست", Description = "")]
        public ushort Priority { get; set; }

        [Display(Name = "دسترسی به پیج", Description = "")]
        public bool SateIsPage { get; set; }
    }
}
