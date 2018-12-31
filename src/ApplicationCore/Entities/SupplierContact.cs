﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Abstract;

namespace ApplicationCore.Entities
{
    public class SupplierContact:BaseContact
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
