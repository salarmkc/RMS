using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesApp.Pages
{
    public partial class SalePage : Form
    {
        public SalePage()
        {
            InitializeComponent();
        }

        private void txtScanBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CallBarcode(txtScanBarcode.Text);
           
        }

        private void CallBarcode(string barcode)
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                
                

                dgvItemSales.Rows.Add();
                dgvItemSales.Rows[dgvItemSales.Rows.Count - 1].Cells["clnStuffName"].Value = barcode;
                txtScanBarcode.Clear();
                txtScanBarcode.Focus();
            }
        }
    }
}
