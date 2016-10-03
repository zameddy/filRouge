using MiniFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFilRouge.Metier
{
    public interface IMagasin
    {
        Magasin AjouterMagasin(Magasin m);
        void AddProduitMagasin(int MagasinId,int ProduitId,int quantite);
        ICollection<Magasin> findAllMagasins();
        Magasin findMagasin(int id);

        ICollection<ProduitMagasinModel> findAllMagasinsProduits();
    }
}
