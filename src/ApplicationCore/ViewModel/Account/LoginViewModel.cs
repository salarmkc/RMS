using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.ViewModel.Account
{
    public class LoginViewModel
    {
        
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("من را به خاطر بسپار")]

        public bool RememberMe { get; set; }
    }
}
