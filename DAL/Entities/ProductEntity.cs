using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
