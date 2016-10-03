using MiniFilRouge.Metier;
using MiniFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFilRouge.Dao
{
    public interface IDao
    {
        Produit AddProduit(Produit p);
        void DeleteProduit(Produit p);
        Produit findProduit(int refProduit);
        Produit MajProduit(Produit p);
        ICollection<Produit> findAllProduits();
        ICollection<ProduitCatModel> findAllProduitsAndCat();
        ICollection<Produit> findProduitsByMC(string mc);
        ICollection<Produit> ProduitsSelectionnes();
        void DeleteProduit(int refProd);

        Categorie AddCategorie(Categorie p);
        void DeleteCategorie(Categorie p);
        Categorie findCategorie(int refCategorie);
        Categorie MajCategorie(Categorie p);
        ICollection<Categorie> findAllCategories();
        ICollection<Categorie> findCategoriesByMC(string mc);
        void DeleteCategorie(int refProd);

        Magasin AddMagasin(Magasin m);
        Magasin findMagasin(int id);
        void AddProduitMagasin(int MagasinId,int ProduitId,int quantite);
        ICollection<Magasin> findAllMagasins();
        ICollection<ProduitMagasinModel> findAllMagasinsProduits();

        UserAccount AddUser(UserAccount u);
        UserAccount LoginUser(UserAccount u);
        ICollection<UserAccount> findAllUser();

        void SauvegarderLigneCommande(LigneCommande lc);
        void EnregistrerCommande(Commande c);

        Commande enregistrerCommande(Panier p, UserAccount u);

        ICollection<MesCommandes> ListerMesCommandes(int IdUser);
        void ProduitsVisites(Consulter ct);
    }
}
