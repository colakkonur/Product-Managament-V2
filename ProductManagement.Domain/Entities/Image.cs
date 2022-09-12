using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagement.Domain.Entities
{
    public partial class Image
    {
        public Image()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
