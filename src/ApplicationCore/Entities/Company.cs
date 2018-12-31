using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Abstract;
using ApplicationCore.Entities.Share;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Company : BaseEntity
    {
        [Display(Name = "نام شرکت", Description = "فیلد نام شرکت")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "نام لاتین شرکت", Description = "فیلد نام لاتین شرکت")]
        

        public string LatinName { get; set; }
        [Display(Name = "نام قانونی شرکت", Description = "فیلد نام لاتین شرکت")]
        

        public string LegalName { get; set; }
        [Display(Name = "تاریخ شروع فعالیت ", Description = "")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاریخ شروع فعالیت ", Description = "")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
  
        [Display(Name = "شبکه", Description = "")]
        

        public  int NetworkInfoId { get; set; }
        public NetworkInfo NetworkInfo { get; set; }
        [Display(Name = "لوگوی شرکت", Description = "")]

        public byte[] PhotoId { get; set; }

        public ICollection<CompanyContact> CompanyContacts { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public Company()
        {
            CompanyContacts = new List<CompanyContact>();
            Branches = new List<Branch>();
        }

    }
}
