using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.Static
{
    [Table("Provinces", Schema = "static")]
    public class Province : BaseEntity
    {
        [Display(Name = "نام استان", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Name { get; set; }
        //[Display(Name = "منطقه", Description = "")]
        //[Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        //[StringLength(50, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        //public string AreaId { get; set; }
        //public Area Area { get; set; }
        [Display(Name = "کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        

        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Display(Name = "کد استان", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]

        public ushort Code { get; set; }

        public ICollection<City> Cities { get; set; }

        public Province()
        {
            Cities=new List<City>();
        }
    }
}
