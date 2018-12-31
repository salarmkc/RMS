using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.Network
{
    public class NetworkInfoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "آی پی", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(50, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Ip { get; set; }
        [Display(Name = "پورت", Description = "")]
        public int Port { get; set; }

        [Display(Name = "مک آدرس", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(29, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string Mac { get; set; }
        [Display(Name = "نام میزبان", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [StringLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]

        public string HostName { get; set; }
    }
}
