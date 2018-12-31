using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Drawer : BaseEntity
    {
        [Display(Name = "کاربر انتسابی", Description = "کاربری که کشو پول بهش انتساب داده شده است")]
        public int OwnerUserId { get; set; }
        public virtual User OwnerUser { get; set; }
        [Display(Name = "کشو پول", Description = "نام کشو پول")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
    }
}
