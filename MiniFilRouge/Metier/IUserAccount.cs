using MiniFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFilRouge.Metier
{
    public interface IUserAccount
    {
        UserAccount AddUserAccount(UserAccount u);
        UserAccount LoginUser(UserAccount u);
        ICollection<UserAccount> findAllUser();
        Commande enregistrerCommande(Panier p, UserAccount u);

        void SauvegarderLigneCommande(LigneCommande lc);
        void EnregistrerCommande(Commande c);

        ICollection<MesCommandes> ListerMesCommandes(int IdUser);

        void ProduitsVisites(Consulter ct);

    }
}
