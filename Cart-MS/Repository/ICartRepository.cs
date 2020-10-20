using Cart_MS.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart_MS.Repository
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAll();
        Cart GetById(int id);
        Cart Post(Cart model);
    }
}
