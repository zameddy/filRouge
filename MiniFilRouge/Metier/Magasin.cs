using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class Magasin
    {
        public int MagasinId { get; set; }
        public string NomMagasin { get; set; }

        public virtual ICollection<ProduitMagasin> MesProduitsMagasins { get; set; }

    }
}