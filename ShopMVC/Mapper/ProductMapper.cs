using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using UIL.Models;

namespace UIL.Mapper
{
    public class ProductMapper
    {
        public static ProductModel ToModel(ProductDto product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price
            };
        }
        public static ProductDto ToDto(ProductModel product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
