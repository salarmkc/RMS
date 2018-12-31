using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Measure : BaseEntity
    {
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
