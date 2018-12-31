using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class StuffSupplier : BaseEntity
    {
        [Display(Name = "کد کالا", Description = "")]
        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }
        [Display(Name = "تامین کننده", Description = "")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
