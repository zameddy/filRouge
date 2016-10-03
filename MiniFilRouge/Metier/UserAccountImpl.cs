using MiniFilRouge.Dao;
using MiniFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFilRouge.Metier
{
    public class UserAccountImpl : IUserAccount 
    {
        public IDao Idao = new DaoImpl();
        public UserAccount AddUserAccount(UserAccount u)
        {
            return Idao.AddUser(u);
        }

        public UserAccount LoginUser(UserAccount u)
        {
            return Idao.LoginUser(u);
        }
        public ICollection<UserAccount> findAllUser()
        {
            return Idao.findAllUser();
        }

        public Commande enregistrerCommande(Panier p, UserAccount u)
        {
            return Idao.enregistrerCommande(p,u);
        }

        public void SauvegarderLigneCommande(LigneCommande lc)
        {
            Idao.SauvegarderLigneCommande(lc);
        }

        public void EnregistrerCommande(Commande c)
        {
            Idao.EnregistrerCommande(c);
        }

        public ICollection<MesCommandes> ListerMesCommandes(int IdUser)
        {
            return Idao.ListerMesCommandes(IdUser);
        }

        public void ProduitsVisites(Consulter ct)
        {
            Idao.ProduitsVisites(ct);
        }
    }
}