using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagement.Domain.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int? Quantity { get; set; }
        public int CategoryId { get; set; }
        public int PricesId { get; set; }
        public int? ImagesId { get; set; }
        public int CompanyId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual Image Images { get; set; }
        public virtual Price Prices { get; set; }
    }
}
