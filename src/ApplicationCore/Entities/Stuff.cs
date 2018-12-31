using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Static;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Stuff : BaseEntity
    {
        [Display(Name = "کد دستی کالا", Description = "کدی جهت دسترسی سریع به کالا و استفاده در سیستم")]
        public int ManualCode { get; set; }
        [Display(Name = "نام کالا", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نام کالا", Description = "")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LatinName { get; set; }
        [Display(Name = "نام کالا", Description = "")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string ShortName { get; set; }
        [Display(Name = " گروه کالا", Description = "")]
        public int StuffGroupId { get; set; }
        public StuffGroup StuffGroup { get; set; }
        [Display(Name = " واحد کالا", Description = "")]
        public int StuffUnitId { get; set; }
        public StuffUnit StuffUnit { get; set; }
        [Display(Name = "تارنمای اینترنتی کالا", Description = "")]
        public string WebUrl { get; set; }
        [Display(Name = " واحد کالا", Description = "")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        //public int BarcodeId { get; set; }
        public ICollection<PriceConsumer> PriceConsumers { get; set; }
        

        public Stuff()
        {
            PriceConsumers = new List<PriceConsumer>();

        }
    }
}
