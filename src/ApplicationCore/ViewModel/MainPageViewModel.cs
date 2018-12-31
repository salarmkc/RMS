using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel
{
    public class MainPageViewModel
    {
        public string DateTime { get; set; }
        public string UserNickName { get; set; }

        public List<ManagementAppMenu> Type { get; set; }
    }
}
