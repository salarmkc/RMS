using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.BaseInfo
{
    public class MeasureViewModel
    {
        public int Id { get; set; }
        [Display(Name = "طول", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public int X { get; set; }
        [Display(Name = "عرض", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public int Y { get; set; }
        [Display(Name = "مساحت", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public int Area { get; set; }
    }
}
