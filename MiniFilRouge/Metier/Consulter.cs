using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class Consulter
    {
        public int ConsulterId { get; set; }

        public int ProduitId { get; set; }

        public int UserAccountId { get; set; }

        public DateTime DateConsultation { get; set; }

        public virtual Produit Produit { get; set; }
        public virtual UserAccount UserAccount { get; set; }
    }
}