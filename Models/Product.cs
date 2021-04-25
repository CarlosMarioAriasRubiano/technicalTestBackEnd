using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Models
{
    public partial class Product
    {
        public Product()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
