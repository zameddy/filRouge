using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class LigneCommande
    {
        [Key, Column(Order = 0)]
        public int CommandeId { get; set; }
        [Key, Column(Order = 1)]
        public int ProduitId { get; set; }

        public virtual Commande Commande { get; set; }
        public virtual Produit Produit { get; set; }

        public int quantite { get; set; }
        public int prix { get; set; }


    }
}