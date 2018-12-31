using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
using ApplicationCore.Entities.Static;

namespace ApplicationCore.ViewModel.Location
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        [Display(Name = "کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        

        public int CountryId { get; set; }
        public Country Country { get; set; }

        [Display(Name = "استان", Description = "")]
        
        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        [Display(Name = "شهر", Description = "")]
        
        public int CityId { get; set; }
        public City City { get; set; }
       
      
        [Display(Name = "شعبه", Description = "")]
        
        public int BranchId { get; set; }
        public Entities.Branch Branch { get; set; }
    }
}
