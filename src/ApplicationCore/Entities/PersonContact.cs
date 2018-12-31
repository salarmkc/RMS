using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Abstract;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class PersonContact:BaseContact
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
