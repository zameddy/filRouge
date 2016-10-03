using MiniFilRouge.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniFilRouge.Models;

namespace MiniFilRouge.Metier
{
    public class MagasinImpl : IMagasin
    {
        public IDao Idao = new DaoImpl();
        public void AddProduitMagasin(int MagasinId, int ProduitId, int quantite)
        {
             Idao.AddProduitMagasin(MagasinId, ProduitId,quantite);
        }

        public Magasin AjouterMagasin(Magasin m)
        {
          return  Idao.AddMagasin(m);
        }

        public ICollection<Magasin> findAllMagasins()
        {
            return Idao.findAllMagasins();
        }

        public ICollection<ProduitMagasinModel> findAllMagasinsProduits()
        {
            return Idao.findAllMagasinsProduits();
        }

        public Magasin findMagasin(int id)
        {
            return Idao.findMagasin(id);
        }

    }
}