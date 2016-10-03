using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    [NotMapped]
    public class Panier
    {
        // public ICollection<LigneCommande> MesLignesDeCommande { get; set; }
        public Dictionary<int, LigneCommande> MesLignesDeCommande = 
            new Dictionary<int, LigneCommande>();

        public void addLigne(Produit p,int quantite)
        {
            LigneCommande lc;
            MesLignesDeCommande.TryGetValue(p.ProduitId,out lc);
            if (lc == null)
            {
                LigneCommande art = new LigneCommande();
                art.Produit = p;
                art.quantite = quantite;
                art.prix = p.prix;
                MesLignesDeCommande.Add(p.ProduitId, art);
            } else
            {
                lc.quantite +=quantite;
            }
        }

        public ICollection<LigneCommande> getItems()
        {
            return MesLignesDeCommande.Values;
        }
        /*nombre de ligne dans une commande*/
        public int getSize()
        {
            return MesLignesDeCommande.Count();
        }
        /* total panier*/
        public double Total()
        {
            double total = 0;
            foreach (var l in MesLignesDeCommande.Values)
            {
                total += l.quantite * l.prix;
            }
            return total;
        }
        /*supprimer ligne de commande*/
        public void deleteItem(int idProduit)
        {
            MesLignesDeCommande.Remove(idProduit);
        }
    }
}