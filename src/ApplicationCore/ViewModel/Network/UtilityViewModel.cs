using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities.Share;

namespace ApplicationCore.ViewModel.Network
{
    public class UtilityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام ابزار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "هدف", Description = "")]
        public int BaseInfoTargetId { get; set; }//BaseInfo

        [Display(Name = "نام اصلی", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string MainName { get; set; }
        [Display(Name = "اطلاعات شبکه", Description = "")]
        public int NetworkInfoId { get; set; }
        public virtual NetworkInfo NetworkInfo { get; set; }
        [Display(Name = "سازنده", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Manufacturer { get; set; }
        [Display(Name = "مدل", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Model { get; set; }
        [Display(Name = "رنگ", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]


        public int BaseInfoColorId { get; set; }

        [Display(Name = "تیپ کاری", Description = "")]
        public int BaseInfoNatureId { get; set; }//BaseInfo tip kari
        public ICollection<Entities.Share.UtilityDetail> UtilityDetails { get; set; }

        public UtilityViewModel()
        {
            UtilityDetails = new List<Entities.Share.UtilityDetail>();
        }
    }
}
