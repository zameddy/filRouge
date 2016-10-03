using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyShoppingCart.Metier
{
    public class InvoiceDetail
    {
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        public int InvoiceId { get; set; }

        public int Quantity { get; set; }
        public int price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}