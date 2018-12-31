using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Share;
using ApplicationCore.Entities.Static;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Branch : BaseEntity
    {
        [Display(Name = "شعبه", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "  مساحت", Description = "")]
        public int? MeasureId { get; set; }
        public Measure Measure { get; set; }
       
        [Display(Name = "شبکه", Description = "")]
        public  int? NetworkInfoId { get; set; }
        public NetworkInfo NetworkInfo { get; set; }

        [Display(Name = "تاریخ شروع فعالیت ", Description = "")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ شروع فعالیت ", Description = "")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [Display(Name = "کد بازرگانی ", Description = "")]
        public int CommercialCode { get; set; }

        [Display(Name = "شماره ثبت", Description = "")]
        public int RegisterCode { get; set; }

        [Display(Name = "کمپانی", Description = "")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<BranchGallery> BranchGalleries { get; set; }
        public ICollection<BranchContact> BranchContacts { get; set; }
        public Branch()
        {
            BranchGalleries = new List<BranchGallery>();
            BranchContacts = new List<BranchContact>();
        }

    }
}
