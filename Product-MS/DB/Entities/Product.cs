using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_MS.DB.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

    }
}
