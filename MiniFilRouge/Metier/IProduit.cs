using MiniFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFilRouge.Metier
{
    public interface IProduit
    {
        Produit AddProduit(Produit p);
        void DeleteProduit(Produit p);
        Produit findProduit(int refProduit);
        Produit MajProduit(Produit p);
        ICollection<Produit> findAllProduits();
        ICollection<Produit> findProduitsByMC(string mc);
        void DeleteProduit(int refProd);
        ICollection<ProduitCatModel> findAllProduitsAndCat();
    }
}
