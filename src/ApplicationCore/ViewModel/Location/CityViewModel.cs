using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.Location
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام شهر", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]

        public string Name { get; set; }

        public int ProvinceId { get; set; }
        [Display(Name = "استان", Description = "")]

        public string ProvinceName  { get; set; }
        [Display(Name = "کد شهر", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]

        public ushort Code { get; set; }
    }
}
