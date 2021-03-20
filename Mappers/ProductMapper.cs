using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappers
{
    public static class ProductMapper
    {
        public static ProductEntity ToEnity(ProductDto product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description=product.Description,
                Price=product.Price
            };
        }
        public static ProductDto ToDto(ProductEntity product)
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
