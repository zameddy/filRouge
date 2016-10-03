using MiniFilRouge.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFilRouge.Controllers
{
    public class CategorieController : Controller
    {
        public ICategorie Icat = new CategorieImpl();
        // GET: Categorie
        public ActionResult Index()
        {
            ICollection<Categorie> res = Icat.findAllCategories();
            return View(res);
        }

        public ActionResult Chercher()
        {
            return View();
        }
        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult AjouterCategorie()
        {
            ICollection<Categorie> res = Icat.findAllCategories();
            return View(res);
        }
        [HttpPost]
        public ActionResult AjouterCategorie(Categorie c)
        {
            Icat.AddCategorie(c);
            ICollection<Categorie> res = Icat.findAllCategories();
            return View(res);
        }
        /* suppression d'une catégorie*/
        public ActionResult Delete(int id)
        {
            Icat.DeleteCategorie(id);
            return RedirectToAction("AjouterCategorie");
        }
        // GET: Categorie/Edit/5
        public ActionResult Edit(int id)
        {
            Categorie categorie = Icat.findCategorie(id);
            return View(categorie);
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include = "CategorieId,Nom")]Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                Icat.MajCategorie(categorie);
                return RedirectToAction("AjouterCategorie");
            }
            else
            {
                return View(categorie);
            }
        }
    }
}