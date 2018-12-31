using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities.Static;

namespace ApplicationCore.Abstract
{
    public abstract  class BaseContact : BaseEntity
    {
        [Display(Name = "شهر", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        public virtual int CityId { get; set; }
        public virtual City City { get; set; }

        [Display(Name = "شماره ثابت", Description = "")]
        [DataType(DataType.PhoneNumber)]
        public virtual string Tel { get; set; }

        [Display(Name = "شماره همراه", Description = "")]
        public virtual string Mobile { get; set; }

        [Display(Name = "ایمیل", Description = "")]
        [EmailAddress]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public virtual string Email { get; set; }

        [Display(Name = "شماره فکس", Description = "")]
        public virtual string Fax { get; set; }

        [Display(Name = "آدرس", Description = "")]
        public virtual string Address { get; set; }

        [Display(Name = "وب سایت", Description = "")]
        [DataType(DataType.Url)]
        public virtual string WebSite { get; set; }

        [Display(Name = "پیش فرض", Description = "")]
        public virtual bool IsPrimary { get; set; }
    }
}
