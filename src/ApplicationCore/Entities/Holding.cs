using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Share;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Holding : BaseEntity
    {
        [Display(Name = "نام هلدینگ", Description = "نام هلدینگ")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string HoldingName { get; set; }
        [Display(Name = "نام هلدینگ", Description = "نام هلدینگ")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string HoldingNameEn { get; set; }
        [Display(Name = "لوگوی هلدینگ", Description = "")]
        public byte[] HoldingLogo { get; set; }
        [Display(Name = "ارتباط", Description = "")]
        public ICollection<HoldingContact> HoldingContacts { get; set; }
        public Holding()
        {
            HoldingContacts = new List<HoldingContact>();
        }
    }
}
