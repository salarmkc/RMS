using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.BaseInfo
{
    public class BaseInfoGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام گروه پایه", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public string BaseInfoGroupName { get; set; }
        [Display(Name = "نام لاتین گروه پایه", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public string BaseInfoGroupText { get; set; }
    }
}
