using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities.Sale
{
    public class InvoiceLine : BaseEntity
    {
        [Display(Name = "کد فاکتور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        [Display(Name = "کد کالا")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public float Quantity { get; set; }

        [Display(Name = "قیمت کالا")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public decimal Price { get; set; }

    }
}
