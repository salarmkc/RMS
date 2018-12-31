using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class BranchGallery : BaseEntity
    {
        [Display(Name="نام")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public byte[] Photo { get; set; }
        [Display(Name = "تصویر اصلی")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public bool IsPrimary { get; set; }
    }
}
