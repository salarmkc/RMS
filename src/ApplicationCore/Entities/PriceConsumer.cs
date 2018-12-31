using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class PriceConsumer : BaseEntity
    {
        [Display(Name = "کد کالا", Description = "")]
        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }
        [Display(Name = "قیمت مصرف کننده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }
    }
}
