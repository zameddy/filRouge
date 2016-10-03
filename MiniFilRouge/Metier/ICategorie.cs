using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFilRouge.Metier
{
    public interface ICategorie
    {
        Categorie AddCategorie(Categorie p);
        void DeleteCategorie(Categorie p);
        Categorie findCategorie(int refCategorie);
        Categorie MajCategorie(Categorie p);
        ICollection<Categorie> findAllCategories();
        ICollection<Categorie> findCategoriesByMC(string mc);
        void DeleteCategorie(int refProd);
    }
}
