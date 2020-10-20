using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart_MS.DB.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int User { get; set; }
        public string Name { get; set; }

    }
}
