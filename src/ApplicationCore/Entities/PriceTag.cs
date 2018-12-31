using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Share;
using ApplicationCore.Entities.Static;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    [Table("PriceTags",Schema = "sale")]
    public class PriceTag : BaseEntity
    {
       
        [Display(Name = "شهر", Description = "")]

        public int CityId { get; set; }
        public City City { get; set; }
        [Display(Name = "شعبه", Description = "")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [Display(Name = "کد کالا", Description = "")]
        

        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }
        [Display(Name = "قیمت مصرف کننده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [DataType(DataType.Currency)]
        public Decimal Price { get; set; }
    }
}
