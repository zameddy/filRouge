using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShoppingCart.Metier
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreation { get; set; }
        public bool status { get; set; }

        public virtual ICollection<InvoiceDetail> ProductInvoiceDetail { get; set; }
    }
}