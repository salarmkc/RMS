using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Barcode : BaseEntity

    {
        [Display(Name = "نوع بارکد", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Type { get; set; }

        [Display(Name = "بارکد کالا", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        

        public string BarcodeStuff { get; set; }
        [Display(Name = "کالا", Description = "")]
        
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]

        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }

        [Display(Name = "بارکد پیش فرض", Description = "")]
        public bool IsDefault { get; set; }

        

    }
}