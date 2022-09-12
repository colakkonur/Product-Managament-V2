using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagement.Domain.Entities
{
    public partial class Price
    {
        public Price()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public double? TaxRate { get; set; }
        public double? TaxAmount { get; set; }
        public double? Margin { get; set; }
        public double? Price1 { get; set; }
        public double? ShippingCost { get; set; }
        public double? DiscountRate { get; set; }
        public double? DiscountAmount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
