using Cart_MS.DB;
using Cart_MS.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart_MS.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly Context _contxt;

        public CartRepository(Context contxt)
        {
            _contxt = contxt;
        }
        public IEnumerable<Cart> GetAll()
        {
            
            //var clist = _contxt.Carts.Include(r => r).ToList();
            var clist = _contxt.Carts.ToList();
            return clist;
        }

        public Cart GetById(int id)
        {

            //return _contxt.Carts.FirstOrDefault(p => p.Id == id);

            return _contxt.Carts.Find(id);

        }

        public Cart Post(Cart model)
        {
            _contxt.Carts.Add(model);
            _contxt.SaveChanges();
            return model;
        }
    }
}
