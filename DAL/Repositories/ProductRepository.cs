using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAL
{
    public class ProductRepository : IProductRepository
    {
        private List<ProductEntity> products = new List<ProductEntity>();
        public void Add(ProductEntity product)
        {
            product.Id = products.Count;
            products.Add(product);
        }

        public void Delete(int product_id)
        {
            products.RemoveAll(x => x.Id == product_id);
        }

        public ProductEntity GetProductById(int product_id)
        {
            ProductEntity item = (from p in products
                               where p.Id == product_id
                               select p).First();
            return item;
        }

        public void EditProduct(int product_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return products;
        }

        public IEnumerable<ProductEntity> GetProductByName(string product_name)
        {
            return products.Where(x => x.Name == product_name);
        }

        public int Count()
        {
            return products.Count();
        }

        public void EditProduct(int product_id, string field, string new_value)
        {
            FieldInfo[] members = typeof(ProductEntity).GetFields();
            var f = from x in members
                    where nameof(x).Equals(field)
                    select x;
            if (f == null) throw new ArgumentNullException("field");
            ProductEntity edit = products.Find(x => x.Id == product_id);
            products.Find(x => x.Id == product_id).GetType().GetProperty(field).SetValue(edit, new_value);
        }
    }
}
