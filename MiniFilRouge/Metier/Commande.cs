using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class Commande
    {
        public int CommandeId { get; set; }
        public string Statut { get; set; }
        public DateTime DateCommande { get; set; } 

        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<LigneCommande> MesLigneCommandes { get; set; }
    }
}