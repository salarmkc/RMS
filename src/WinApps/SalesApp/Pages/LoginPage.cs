using System;
using System.Windows.Forms;

namespace SalesApp.Pages
{
    public partial class LoginPage : Form// DevComponents.DotNetBar.Metro.MetroForm
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SalePage salePage = new SalePage())
            {
                salePage.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }


    }
}
