using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities.Static
{
    public class tLog : BaseEntity
    {

        [Display(Name = "کد نوع لاگ", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int LogTypeId { get; set; }
        public LogType LogType { get; set; }

        [Display(Name = "کد اپراتور", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        
        public int LogUserId { get; set; }
        public User User { get; set; }

        [Display(Name = "نام قسمتی که در آن خطا رخ داده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(5000, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LogFormAction { get; set; }

        [Display(Name = "شرح نوع عملیات", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(5000, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LogAcionText { get; set; }

        [Display(Name = "نام سیستمی که خطا در آن رخ داده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LogHostName { get; set; }

        [Display(Name = "آی پی سیستمی که خطا در آن رخ داده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LogIp { get; set; }
    }
}
