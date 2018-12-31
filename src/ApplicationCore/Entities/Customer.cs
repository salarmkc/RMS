using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Static;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Customer : BaseEntity
    {
   [Display(Name = "شخص", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        

        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Display(Name = "آشنایی", Description = "")]
        

        public int BaseInfoIntroductionId { get; set; }//BaseInfo

        public BaseInfo BaseInfoIntroduction { get; set; }
    }
}
