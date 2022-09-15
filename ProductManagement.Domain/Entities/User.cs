using System;
using System.Collections.Generic;

#nullable disable

namespace ProductManagement.Domain.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
