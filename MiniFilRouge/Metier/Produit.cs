using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniFilRouge.Metier
{
    public class Produit
    {
        public int ProduitId { get; set; }
        [Required(ErrorMessage ="{0} obligatoire")]
        public string NomProduit { get; set; }
        public int stock { get; set; }
        public int prix { get; set; }
        public bool selectionne { get; set; }

        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }

        public virtual ICollection<ProduitMagasin> MesMagasinsProduits { get; set; }
        public virtual ICollection<LigneCommande> MesLigneCommandeProduit { get; set; }
        public virtual ICollection<Consulter> Consultations { get; set; }
    }
}