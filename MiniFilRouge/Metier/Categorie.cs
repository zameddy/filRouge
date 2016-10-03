using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class Categorie
    {
       [Display(Name="Id Catégorie")]
        public int CategorieId { get; set; }
        //[Required]
        [StringLength(15,ErrorMessage ="15 au maximum")]
        public string Nom { get; set; }

        public virtual ICollection<Produit> MesProduits { get; set; }
    }
}