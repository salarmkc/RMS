using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Static;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class PaymentGroup : BaseEntity
    {
        [Display(Name = "شاخه اصلی", Description = "")]

        public int ParentId { get; set; }
        public PersonGroup Parent { get; set; }
        [Display(Name = "نوع روش پرداخت", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Class { get; set; }
        [Display(Name = "ارز", Description = "")]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
