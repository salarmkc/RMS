using System.Collections.Generic;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities.Static
{
    [Table("Countries", Schema = "static")]
    public class Country : BaseEntity
    {
        [Display(Name = "ISO", Description = "")]
        [StringLength(2, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string ISO { get; set; }

        [Display(Name = "نام کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }


        [Display(Name = "نام مرسوم", Description = "")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LatinName { get; set; }

        [Display(Name = "ISO3", Description = "")]
        [StringLength(3, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string ISO3 { get; set; }

        [Display(Name = "کد کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public string CountryCode { get; set; }


        public ICollection<Province> Provinces { get; set; }
        public Country()
        {
            Provinces=new List<Province>();
        }
    }
}
