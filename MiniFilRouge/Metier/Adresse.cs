using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public string NumRue { get; set; }
        public string NomRue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}