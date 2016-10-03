using MyShoppingCart.Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyShoppingCart.Metier
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext() : base("ShoppingCart")
        {

        }
        public DbSet<Product> Products { get; set;}
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}