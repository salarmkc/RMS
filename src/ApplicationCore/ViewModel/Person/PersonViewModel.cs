using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore.ViewModel.Person
{
  public  class PersonViewModel
    {
        public int Id { get; set; }
        public int PersonGroupId { get; set; }
        public PersonGroup PersonGroup { get; set; }
        [Display(Name = "نام شخص", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string FirstName { get; set; }
        [Display(Name = "نام شخص", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(256, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get; set; }
        [Display(Name = "تاریخ تولد", Description = "")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "جنسیت", Description = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد نمائید")]
        [MaxLength(20, ErrorMessage = "مقدار  {0} نباید بیشتر از {1} کارکتر باشد")]
        public string Gender { get; set; }
        public ICollection<PersonContact> PersonContacts { get; set; }
        //  public  ICollection<PersonGroup> PersonGroups { get; set; }

        [Display(Name = "عکس شخص ", Description = "")]
        public byte[] PhotoId { get; set; }

        public PersonViewModel()
        {
            PersonContacts = new List<PersonContact>();
            // PersonGroups=new List<PersonGroup>();
        }
    }
}
