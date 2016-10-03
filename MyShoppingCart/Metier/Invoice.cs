using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingCart.Metier
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceInvoiceDetail { get; set; }
    }
}