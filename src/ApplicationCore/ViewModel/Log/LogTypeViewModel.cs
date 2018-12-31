using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.Log
{
    public class LogTypeViewModel
    {
        public string  Id { get; set; }
        [Display(Name = "عنوان نوع لاگ", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LogTypeName { get; set; }

        [Display(Name = "عنوان لاتین نوع لاگ", Description = "")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LogTypeEnName { get; set; }
    }
}
