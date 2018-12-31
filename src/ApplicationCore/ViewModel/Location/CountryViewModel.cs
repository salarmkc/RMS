using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.Location
{
    public class CountryViewModel
    {
        public int Id { get; set; }
  

        [Display(Name = "نام کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }


        [Display(Name = "نام لاتین", Description = "")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LatinName { get; set; }
        [Display(Name = "ISO", Description = "")]
        [StringLength(2, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string ISO { get; set; }

        [Display(Name = "ISO3", Description = "")]
        [StringLength(3, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string ISO3 { get; set; }

        [Display(Name = "کد کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public string CountryCode { get; set; }
        

    }
}
