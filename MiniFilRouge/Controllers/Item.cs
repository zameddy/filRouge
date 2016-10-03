using MiniFilRouge.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Controllers
{
    public class Item
    {
        private Produit pr = new Produit();
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Produit Pr
        {
            get
            {
                return pr;
            }

            set
            {
                pr = value;
            }
        }

        public Item() 
        {
        }
        public Item(Produit produit,int quantity)
        {
            this.pr = produit;
            this.quantity = quantity;
        }
    }
}