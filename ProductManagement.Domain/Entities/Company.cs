using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagement.Domain.Entities
{
    public partial class Company
    {
        public Company()
        {
            Products = new HashSet<Product>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FullAdress { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
