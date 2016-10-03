using MiniFilRouge.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class CategorieImpl : ICategorie
    {
        public IDao Idao = new DaoImpl();
        public Categorie AddCategorie(Categorie p)
        {
            return Idao.AddCategorie(p);
        }

        public void DeleteCategorie(int refProd)
        {
            Idao.DeleteCategorie(refProd);
        }

        public void DeleteCategorie(Categorie p)
        {
            Idao.DeleteCategorie(p);
        }

        public ICollection<Categorie> findAllCategories()
        {
            return Idao.findAllCategories();
        }

        public Categorie findCategorie(int refCategorie)
        {
            return Idao.findCategorie(refCategorie);
        }

        public ICollection<Categorie> findCategoriesByMC(string mc)
        {
            return Idao.findCategoriesByMC(mc);
        }

        public Categorie MajCategorie(Categorie p)
        {
            return Idao.MajCategorie(p);
        }
    }
}