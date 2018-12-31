using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities.Static
{
[Table("Currencies", Schema = "static")]
    public class Currency:BaseEntity
    {
        [Display(Name = "نام", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string  CurrencyName { get; set; }
        [Display(Name = "سمبل", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(10, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Symbol { get; set; }
           [Display(Name = "تعداد اعشار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]

        public ushort DecimalCount { get; set; }
           [Display(Name = "کشور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
