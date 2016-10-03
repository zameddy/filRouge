using MiniFilRouge.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniFilRouge.Models;

namespace MiniFilRouge.Metier
{
    public class ProduitImpl : IProduit
    {
        public IDao Idao = new DaoImpl();
        public Produit AddProduit(Produit p)
        {
            return Idao.AddProduit(p);
        }

        public void DeleteProduit(int refProd)
        {
            Idao.DeleteProduit(refProd);
        }

        public void DeleteProduit(Produit p)
        {
            Idao.DeleteProduit(p);
        }

        public ICollection<Produit> findAllProduits()
        {
            return Idao.findAllProduits();
        }

        public ICollection<ProduitCatModel> findAllProduitsAndCat()
        {
            return Idao.findAllProduitsAndCat();
        }

        public Produit findProduit(int refProduit)
        {
            return Idao.findProduit(refProduit);
        }

        public ICollection<Produit> findProduitsByMC(string mc)
        {
            return Idao.findProduitsByMC(mc);
        }

        public Produit MajProduit(Produit p)
        {
            return Idao.MajProduit(p);
        }
    }
}