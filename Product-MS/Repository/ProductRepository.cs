using Product_MS.DB;
using Product_MS.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_MS.Repository
{
    public class ProductRepository : IProductRepository 
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _databaseContext.Products.Find(id);
        }

        public void PostModel(Product model)
        {

            _databaseContext.Products.Add(model);
            _databaseContext.SaveChanges();
        }
    }
}
