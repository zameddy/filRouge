using MiniFilRouge.Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Dao
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext() : base("MiniFilRouge")
        {

        }
        public DbSet<Categorie> Categories { get; set;}
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Magasin> Magasins { get; set; }
        public DbSet<ProduitMagasin> ProduitsMagasins { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<LigneCommande> LignesCommandes { get; set; }
        public DbSet<Consulter> ConsultationsProduits { get; set; }
    }
}