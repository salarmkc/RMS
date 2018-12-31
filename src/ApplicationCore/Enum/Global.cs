using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Enum
{

    public enum SortOrder
    {
        [Display(Name = "Desc")]
        Desc = 1,
        [Display(Name = "Asc")]
        Asc = 2,



    };


    public enum SortBy
    {
        [Display(Name = "Manual Code")]
        ManualCode = 1,
        [Display(Name = "Display Name")]
        DisplayName = 2,

    };
}
