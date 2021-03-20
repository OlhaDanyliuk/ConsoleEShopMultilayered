using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validation
{
    public class ValidationProduct 
    {
        public ProductDto Add(string productData)
        {
            ProductDto new_product;
            try
            {
                string[] items = productData.Split(',');
                new_product = new ProductDto
                {
                    Id = int.Parse(items[0]),
                    Name = items[1],
                    Category = items[2],
                    Description=items[3],
                    Price = int.Parse(items[4])
                };
            }
            catch
            {
                throw new ArgumentException("Not valid product data");
            }
            return new_product;
        }
    }
}
