using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities.Sale
{
    public class Invoice : BaseEntity
    {
        [Display(Name = "مشتری")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "صندوق")]
        [Required(ErrorMessage = "{0} بایستی  مشخص گردد")]
        public int CashDeskId { get; set; }
        public CashDesk CashDesk { get; set; }

        [Display(Name = "روش پرداخت")]
        [Required(ErrorMessage = " {0} بایستی مشخص گردد")]
        public int DrawerPaymentId { get; set; }
        public DrawerPayment DrawerPayment { get; set; }

        [Display(Name = "کشو پول")]
        [Required(ErrorMessage = "{0} بایستی مشخص گردد")]
        public int DrawerId { get; set; }
        public Drawer Drawer { get; set; }

        public ICollection<InvoiceLine> InvoiceLines { get; set; }

        public Invoice()
        {
            InvoiceLines = new List<InvoiceLine>();
        }

    }
}
