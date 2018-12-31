using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities.Static;

namespace ApplicationCore.ViewModel.BaseInfo
{
    public class BaseInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "گروه", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int BaseInfoGroupId { get; set; }

        public BaseInfoGroup BaseInfoGroup { get; set; }
        [Display(Name = "نام", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نام لاتین", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LatinName { get; set; }
        [Display(Name = "مقدار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Value { get; set; }
    }
}
