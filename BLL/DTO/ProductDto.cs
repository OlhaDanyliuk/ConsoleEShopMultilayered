using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name}, {Category}, {Description}, {Price}";
        }
    }
}
