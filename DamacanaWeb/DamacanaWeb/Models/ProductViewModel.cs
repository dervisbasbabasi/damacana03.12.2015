﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamacanaWeb.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IList<Product> Products {get; set; }
    }
}
