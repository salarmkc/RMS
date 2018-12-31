using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class User : BaseEntity
    {
        [Display(Name = "گروه", Description = "")]
        public int UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        [Display(Name = "نام کاربری", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public virtual string UserName { get; set; }

        [Display(Name = "کلمه عبور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        [Display(Name = "تائیده ایمیل", Description = "")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "تائید دو مرحله ای", Description = "")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "عدم توانایی در دسترسی", Description = "")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "تعداد شماره تلفن", Description = "")]
        public bool PhoneNumberCount { get; set; }

        [Display(Name = "مهر امنیتی", Description = "")]
        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

    }
}
