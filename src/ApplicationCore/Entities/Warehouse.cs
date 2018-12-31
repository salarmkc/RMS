using ApplicationCore.Entities.Share;
using ApplicationCore.Entities.Static;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities
{
    public class Warehouse : BaseEntity
    {
        [Display(Name = "نام انبار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "کد عملیاتی انبار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public string BaseInfoActionCode { get; set; }//BaseInfo
        public BaseInfo BaseInfo { get; set; }
        [Display(Name = "کد دستی انبار", Description = "")]
        public int ManualCode { get; set; }
        [Display(Name = "کد مساحت انبار", Description = "")]
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }
        
        [Display(Name = "انبار اصلی", Description = "انبار پیش فرض")]
        public bool IsDefault { get; set; }
        public ICollection<WarehouseContact> WarehouseContacts { get; set; }

        public Warehouse()
        {
            WarehouseContacts = new List<WarehouseContact>();
        }

    }
}
