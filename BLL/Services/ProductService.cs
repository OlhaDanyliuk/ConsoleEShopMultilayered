
using BLL.DTO;
using BLL.Mappers;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository _repository)
        {
            productRepository = _repository;
        }
        public void Add(ProductDto product)
        {
            productRepository.Add(ProductMapper.ToEnity(product));
        }

        public void Delete(int product_id)
        {
            productRepository.Delete(product_id);
        }

        public ProductDto GetProductById(int product_id)
        {
            return ProductMapper.ToDto(productRepository.GetProductById(product_id));
        }


        public void EditProduct(int product_id, string field, string new_value)
        {
            productRepository.EditProduct(product_id, field, new_value);
        }

        public List<ProductDto> GetProducts()
        {
            List<ProductDto> result = new List<ProductDto> ();
            foreach(var item in productRepository.GetProducts())
            {
                result.Add(ProductMapper.ToDto(item));
            }

            return result;
        }
        public List<ProductDto> GetProductByName(string name)
        {
            List<ProductDto> result = new List<ProductDto>();
            foreach (var item in productRepository.GetProducts())
            {
                if(item.Name==name)
                    result.Add(ProductMapper.ToDto(item));
            }

            return result;
        }
    }
}
