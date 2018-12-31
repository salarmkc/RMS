using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Entities.Share;

namespace ApplicationCore.ViewModel.Network
{
    public class UtilityDetailViewModel
    {
        public int Id { get; set; }
        [Display(Name = "ابزار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]


        public int UtilityId { get; set; }
        public Utility Utility { get; set; }
        [Display(Name = "ویژگی", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Property { get; set; }
        [Display(Name = "مقدار", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Value { get; set; }
    }
}
