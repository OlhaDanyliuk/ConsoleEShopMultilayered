using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IProductService
    {
        void Add(ProductDto product);
        void EditProduct(int product_id, string field, string new_value);
        void Delete(int product_id);
        List<ProductDto> GetProducts();
        List<ProductDto> GetProductByName(string name);
        ProductDto GetProductById(int product_id);
    }
}
