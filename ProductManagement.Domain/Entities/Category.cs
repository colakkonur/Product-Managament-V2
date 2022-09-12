using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagement.Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            InverseMainCategory = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MainCategoryId { get; set; }

        public virtual Category MainCategory { get; set; }
        public virtual ICollection<Category> InverseMainCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
