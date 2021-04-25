using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
