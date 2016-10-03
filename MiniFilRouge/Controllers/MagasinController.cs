using MiniFilRouge.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFilRouge.Controllers
{
    public class MagasinController : Controller
    {
        public IMagasin Imag = new MagasinImpl();
        public IProduit Iprod = new ProduitImpl();
        // GET: Magasin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Magasin m)
        {
            Imag.AjouterMagasin(m);
            return View();
        }
        public ActionResult MagasinProduit()
        {
            ViewBag.MagasinId = new SelectList(Imag.findAllMagasins(), "MagasinId", "NomMagasin");
            ViewBag.ProduitId = new SelectList(Iprod.findAllProduits(), "ProduitId", "NomProduit");
            return View();
        }
        [HttpPost]
        public ActionResult MagasinProduit(ProduitMagasin pm)
        {
            Imag.AddProduitMagasin(pm.MagasinId,pm.ProduitId,pm.quantite);
            ViewBag.MagasinId = new SelectList(Imag.findAllMagasins(), "MagasinId", "NomMagasin");
            ViewBag.ProduitId = new SelectList(Iprod.findAllProduits(), "ProduitId", "NomProduit");
            return View();
        }

        public ActionResult ListMagasinProduit()
        {
            return View(Imag.findAllMagasinsProduits());
        }
    }
}