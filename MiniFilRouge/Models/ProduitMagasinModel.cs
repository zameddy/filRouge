using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Models
{
    public class ProduitMagasinModel
    {
        [Display(Name = "Nom Produit")]
        public string NomProduit { get; set; }
        [Display(Name = "Nom du Magasin")]
        public string NomMagasin { get; set; }
    }
}