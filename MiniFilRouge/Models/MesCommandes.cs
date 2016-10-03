using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Models
{
    public class MesCommandes
    {
        public int UserAccountId { get; set; }

        public string NomClient { get; set; }
        public string PrenomClient { get; set; }

        public string NomProduit { get; set; }
        public int Quantite { get; set; }

        public int PrixTotal { get; set; }
    }
}