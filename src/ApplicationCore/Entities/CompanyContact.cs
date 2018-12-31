using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities
{
    public class CompanyContact : BaseContact
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
