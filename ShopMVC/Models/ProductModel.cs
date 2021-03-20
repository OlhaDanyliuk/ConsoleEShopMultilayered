using System;
using System.Collections.Generic;
using System.Text;

namespace UIL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Category}, {Description}, {Price}";
        }
    }
}
