using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniFilRouge.Metier;
using System.Data.Entity;
using System.Web.Mvc;
using MiniFilRouge.Models;

namespace MiniFilRouge.Dao
{
    public class DaoImpl : IDao
    {

        public Categorie AddCategorie(Categorie c)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Categories.Add(c);
                bdd.SaveChanges();
                return c;
            }
        }

        public Magasin AddMagasin(Magasin m)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Magasins.Add(m);
                bdd.SaveChanges();
                return m;
            }
        }

        public Produit AddProduit(Produit p)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Produits.Add(p);
                bdd.SaveChanges();
                return p;
            }
        }

        public void AddProduitMagasin(ProduitMagasin pm)
        {
            throw new NotImplementedException();
        }

        public void AddProduitMagasin(int p, int m, int qute)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                Produit lep = findProduit(p);
                Magasin lem = findMagasin(m);
                ProduitMagasin pm = new ProduitMagasin();
                pm.Produit = lep;
                pm.Magasin = lem;
                pm.quantite = qute;
                bdd.ProduitsMagasins.Add(pm);
                bdd.SaveChanges();
            }
        }

        public UserAccount AddUser(UserAccount u)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                u.RoleId = 1;
                u.AdresseId = 1;
                bdd.UserAccounts.Add(u);
                bdd.SaveChanges();
                return u;
            }
        }
        public void DeleteCategorie(int refProd)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                Categorie c = bdd.Categories.Find(refProd);
                bdd.Categories.Remove(c);
                bdd.SaveChanges();
            }
        }

        public void DeleteCategorie(Categorie c)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Categories.Remove(c);
                bdd.SaveChanges();
            }
        }

        public void DeleteProduit(int refCat)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                Produit p = bdd.Produits.Find(refCat);
                bdd.Produits.Remove(p);
                bdd.SaveChanges();
            }
        }

        public void DeleteProduit(Produit p)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Produits.Remove(p);
                bdd.SaveChanges();
            }
        }

        public void EnregistrerCommande(Commande c)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                 bdd.Commandes.Add(c);
                 bdd.SaveChanges();
            }
        }

        public Commande enregistrerCommande(Panier p, UserAccount u)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                Commande cmd = new Commande();
                cmd.UserAccount = u;
                cmd.MesLigneCommandes = p.getItems();
                bdd.Commandes.Add(cmd);
                bdd.SaveChanges();
                return cmd;
            }
           
        }

        public ICollection<Categorie> findAllCategories()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Categories.ToList();
            }
        }

        public ICollection<Magasin> findAllMagasins()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Magasins.ToList();
            }
        }

        public ICollection<ProduitMagasinModel> findAllMagasinsProduits()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                var req = from p in bdd.Produits
                          join pm in bdd.ProduitsMagasins
                          on p.ProduitId equals pm.ProduitId
                          join m in bdd.Magasins
                          on pm.MagasinId equals m.MagasinId
                          select new
                          ProduitMagasinModel
                          {
                              NomProduit = p.NomProduit,
                              NomMagasin = m.NomMagasin
                          };
                return req.ToList();
            }
        }

        public ICollection<Produit> findAllProduits()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Produits.ToList();
            }
        }

        public ICollection<ProduitCatModel> findAllProduitsAndCat()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                var req = from p in bdd.Produits
                          join c in bdd.Categories
                          on p.CategorieId equals c.CategorieId
                          select new
                          ProduitCatModel
                          {
                              ProduitId=p.ProduitId,
                              NomProduit=p.NomProduit,
                              prix=p.prix,
                              stock=p.stock,
                              nomCat=c.Nom
                          };
                return req.ToList();
            }
        }

        public ICollection<UserAccount> findAllUser()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.UserAccounts.ToList();
            }
        }

        public Categorie findCategorie(int refCategorie)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Categories.Where
                    (p => p.CategorieId == refCategorie)
                    .FirstOrDefault<Categorie>();
            }
        }

        public ICollection<Categorie> findCategoriesByMC(string mc)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Categories.Where(cat=>cat.Nom.Contains(mc)).ToList();
            }
        }

        public Magasin findMagasin(int id)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Magasins.Find(id);
            }
        }

        public Produit findProduit(int refProduit)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Produits.Where(
                    p=>p.ProduitId== refProduit).
                    FirstOrDefault<Produit>();
            }
        }

        public ICollection<Produit> findProduitsByMC(string mc)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Produits.
                    Where(prod => prod.NomProduit.Contains(mc)).
                    ToList();
            }
        }

        public ICollection<MesCommandes> ListerMesCommandes(int IdUser)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                var req = from p in bdd.Produits
                          join lc in bdd.LignesCommandes
                          on p.ProduitId equals lc.ProduitId
                          join c in bdd.Commandes
                          on lc.CommandeId equals c.CommandeId
                          join u in bdd.UserAccounts
                          on c.UserAccountId equals u.UserAccountId
                          where (u.UserAccountId == IdUser) 
                          select new
                          MesCommandes
                          {
                              NomClient = u.Username,
                              NomProduit = p.NomProduit,
                              PrenomClient = u.LastName,
                              Quantite = lc.quantite,
                              PrixTotal = lc.prix,
                              UserAccountId = u.UserAccountId

                          };
                return req.ToList();
            }
        }
        public UserAccount LoginUser(UserAccount user)
        {

            using (var bdd = new Dao.ApplicationContext())
            {
                var usr = bdd.UserAccounts.FirstOrDefault(u => u.Username == user.Username &&
                                                  u.Password == user.Password);
                return usr;
            }
        }
        public Categorie MajCategorie([Bind(Include = "CategorieId,Nom")]Categorie c)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Entry(c).State = EntityState.Modified;
                bdd.SaveChanges();
                return c;
            }
        }

        public Produit MajProduit(Produit p)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.Entry(p).State = EntityState.Modified;
                bdd.SaveChanges();
                return p;
            }
        }

        public ICollection<Produit> ProduitsSelectionnes()
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                return bdd.Produits.Where(p => p.selectionne == true).ToList();
            }
        }


        public void ProduitsVisites(Consulter ct)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                var req = bdd.ConsultationsProduits.FirstOrDefault(c => c.ProduitId == ct.ProduitId &&
                                                    c.UserAccountId == ct.UserAccountId);
                if (req != null)
                {
                    req.DateConsultation = DateTime.Now;
                    bdd.SaveChanges();
                }
                else
                {
                    bdd.ConsultationsProduits.Add(ct);
                    bdd.SaveChanges();
                }
            }
        }

        public void SauvegarderLigneCommande(LigneCommande lc)
        {
            using (var bdd = new Dao.ApplicationContext())
            {
                bdd.LignesCommandes.Add(lc);
                bdd.SaveChanges();
            }
        }
    }
}