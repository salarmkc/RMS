using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.User
{
    public class UserGroupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "گروه کاربران", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
    }
}
