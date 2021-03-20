
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IProductRepository
    {
        void Add(ProductEntity product);
        int Count();
        void EditProduct(int product_id, string field, string new_value);
        void Delete(int product_id);
        ProductEntity GetProductById(int product_id);
        IEnumerable<ProductEntity> GetProductByName(string product_name);
        IEnumerable<ProductEntity> GetProducts();

    }
}
