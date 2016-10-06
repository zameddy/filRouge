using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class UserAccount
    {
        
        public int UserAccountId { get; set; }
        [Required(ErrorMessage = "Prenom requis")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nom requis")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email requis")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Login requis")]
        [Column(TypeName="varchar")]
        [StringLength(250)]
        [Index("Iusername",IsUnique =true)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mot de passe requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Confirmer votre mot de passe")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set;}
        public virtual Role Role { get; set;}

        public virtual ICollection<Commande> MesCommandes { get; set; }
        public virtual ICollection<Consulter> MesConsultationsProduits { get; set; }

        public int AdresseId { get; set; }
        public virtual Adresse Adresse { get; set; }
    }
}