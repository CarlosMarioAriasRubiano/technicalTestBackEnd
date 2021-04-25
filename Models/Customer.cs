using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
