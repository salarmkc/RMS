using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.Static
{
    [Table("Cities", Schema = "static")]
    public class City : BaseEntity
    {
        [Display(Name = "نام شهر", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Name { get; set; }
        //[Display(Name = "منطقه", Description = "")]
        //[Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        //[StringLength(50, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        
        //public string AreaId { get; set; }
        //public Area Area { get; set; }
        [Display(Name = "استان", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        [Display(Name = "کد شهر", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public ushort Code { get; set; }


    }
}
