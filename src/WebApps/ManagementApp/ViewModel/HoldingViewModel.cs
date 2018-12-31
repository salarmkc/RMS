using ManagementApp.Interface;

namespace ManagementApp.ViewModel
{
    public class HoldingViewModel : ApplicationCore.ViewModel.Holding.HoldingViewModel
    {
        public IFormFile File { get; set; }
    }
}
