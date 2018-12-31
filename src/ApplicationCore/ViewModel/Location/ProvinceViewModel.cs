using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities.Static;

namespace ApplicationCore.ViewModel.Location
{
    public class ProvinceViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام استان", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int CountryId { get; set; }

        public Country Country { get; set; }
        [Display(Name = "پیش شماره استان", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public ushort Code { get; set; }

    }
}
