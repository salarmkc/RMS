using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class StuffGroup : BaseEntity
    {
        [Display(Name = "کد دستی گروه کالا", Description = "")]
        public int ManualCode { get; set; }
        [Display(Name = "نام گروه", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string GroupName { get; set; }
        [Display(Name = "تصویر گروه", Description = "")]
        public string Photo { get; set; }

    }
}
