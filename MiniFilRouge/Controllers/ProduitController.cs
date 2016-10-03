using MiniFilRouge.Metier;
using MiniFilRouge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFilRouge.Controllers
{
    public class ProduitController : Controller
    {
        public IProduit Iproduit = new ProduitImpl();
        public ICategorie Icat = new CategorieImpl();
        // GET: Produit
        public ActionResult Index()
        {
            ICollection<Produit> res = Iproduit.findAllProduits();
            ViewBag.CategorieId = new SelectList(Icat.findAllCategories(), "CategorieId", "Nom");
            return View(res);
            //return View();
        }
        [HttpPost]
        public ActionResult Index(Produit p)
        {
            ICollection<Produit> res = Iproduit.findAllProduits();
            if (ModelState.IsValid)
            { 
            Iproduit.AddProduit(p);
            ViewBag.CategorieId = new SelectList(Icat.findAllCategories(), "CategorieId", "Nom");
            }
            else {
                ViewBag.CategorieId = new SelectList(Icat.findAllCategories(), "CategorieId", "Nom");
            }
            return View(res);
        }
        public ActionResult Edit(int id)
        {
            Produit produit = Iproduit.findProduit(id);
            ViewBag.CategorieId = new SelectList(Icat.findAllCategories(), "CategorieId", "Nom");
            return View(produit);
        }
        [HttpPost]
        public ActionResult Edit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                Iproduit.MajProduit(produit);
                return RedirectToAction("Index");
            }
            else
            {
                return View(produit);
            }
        }
        public ActionResult Delete(int id)
        {
            Iproduit.DeleteProduit(id);
            return RedirectToAction("Index");
        }

        public ActionResult Produits(ProduitCatModel pm)
        {
            ICollection<ProduitCatModel> res = Iproduit.findAllProduitsAndCat();
            return View(res);
        }
    }
}