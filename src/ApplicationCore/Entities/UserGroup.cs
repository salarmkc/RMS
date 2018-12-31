using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class UserGroup : BaseEntity
    {
        [Display(Name = "گروه کاربران", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        public ICollection<User>  Users { get; set; }

        public UserGroup()
        {
            Users=new List<User>();
        }
    }
}
