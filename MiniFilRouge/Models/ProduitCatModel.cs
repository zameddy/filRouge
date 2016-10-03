using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Models
{
    public class ProduitCatModel
    {
        [Display(Name="Id de Produit")]
        public int ProduitId { get; set; }
        [Display(Name = "Nom du Produit")]
        public string NomProduit { get; set; }
        public int stock { get; set; }
        public int prix { get; set; }
        public bool selectionne { get; set; }
        [Display(Name = "Nom de Catégorie")]
        public string nomCat { get; set; }
    }
}