using MiniFilRouge.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFilRouge.Controllers
{
    public class UserAccountController : Controller
    {
        public IUserAccount Iuser = new UserAccountImpl();
        public IProduit Iprod = new ProduitImpl();
        // GET: UserAccount
        public ActionResult Index()
        {
            return View(Iuser.findAllUser());
        }
        public ActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount userAccount )
        {
            if (ModelState.IsValid)
            {
                Iuser.AddUserAccount(userAccount);
                ModelState.Clear();
                ViewBag.Message = userAccount.FirstName+ " "+ userAccount.LastName+ " enregistré";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount userAccount)
        {
         
            var monUser = Iuser.LoginUser(userAccount);
            if (monUser != null)
            {
                Session["UserId"] = monUser.UserAccountId;
                Session["Username"] = monUser.Username;
                Session["user"] = monUser;
                return RedirectToAction("LoggedIn");
               // ViewBag.Message = "Bonjour " + monUser.FirstName + " " + monUser.LastName;
            }
            else
            {
                ModelState.AddModelError("", "utilisateur ou mot de passe incorrect");
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session["UserId"] = null;
            Session["Username"] = null;
            Session["user"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Commander()
        {

            return View(Iprod.findAllProduits());
        }

        [HttpPost]
        public ActionResult Commander(Commande c)
        {
            Panier p = new Panier();

            return View();
        }
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i = 0; i < cart.Count; i++)
                if (cart[i].Pr.ProduitId == id)
                    return i;
                return -1;
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Caddie");
        }
        public ActionResult AjouterCaddie(int id)
        {
            if(Session["cart"]==null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(Iprod.findProduit(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(Iprod.findProduit(id), 1));
                else
                    cart[index].Quantity++;
                Session["cart"] = cart;
            
            }
            return View("Caddie");
        }

        public ActionResult Update(FormCollection fc)
        {
            string[] quantities = fc.GetValues("qute");
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i=0;i < cart.Count;i++)
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
            Session["cart"] = cart;
            return View("Caddie");
        }


        public ActionResult ValiderPanier()
        {
            List<Item> cart = (List<Item>)Session["cart"];
            UserAccount user = (UserAccount)Session["user"];
            //ajouter la commande en BDD
            Commande c = new Commande();
            c.DateCommande = DateTime.Now;
            //c.UserAccount = user;
            c.Statut = "Valide";
            c.UserAccountId = user.UserAccountId;
            Iuser.EnregistrerCommande(c);

            //ajouter des Lignes de Commande en BDD
            foreach(Item item in cart)
            {
                LigneCommande lc = new LigneCommande();
                lc.CommandeId = c.CommandeId;
                lc.quantite = item.Quantity;
                lc.prix = item.Pr.prix;
                lc.ProduitId = item.Pr.ProduitId;
                Iuser.SauvegarderLigneCommande(lc);
            }
            //vider la session Caddie
            Session.Remove("cart");
            return View("Thanks");
        }

        public ActionResult CheckoutCheque()
        {

            List<Item> cart = (List<Item>)Session["cart"];
            UserAccount user = (UserAccount)Session["user"];
            //ajouter la commande en BDD
            Commande c = new Commande();
            c.DateCommande = DateTime.Now;
            //c.UserAccount = user;
            c.Statut = "En Cours";
            c.UserAccountId = user.UserAccountId;
            Iuser.EnregistrerCommande(c);

            //ajouter des Lignes de Commande en BDD
            foreach (Item item in cart)
            {
                LigneCommande lc = new LigneCommande();
                lc.CommandeId = c.CommandeId;
                lc.quantite = item.Quantity;
                lc.prix = item.Pr.prix;
                lc.ProduitId = item.Pr.ProduitId;
                Iuser.SauvegarderLigneCommande(lc);
            }
            //vider la session Caddie
            Session.Remove("cart");
            return View("Thanks");

        }
        public ActionResult MesCommandes(int id)
        {
            return View(Iuser.ListerMesCommandes(id));
        }

        public ActionResult MesConsultations()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            UserAccount user = (UserAccount)Session["user"];
            Consulter c = new Consulter();
            c.DateConsultation = DateTime.Now;
            c.UserAccountId = user.UserAccountId;
            c.ProduitId = id;
            Iuser.ProduitsVisites(c);

            var res = Iprod.findProduit(id);
            return View(res);
        }

        public ActionResult CheckoutPaypal()
        {
            string returnURL = "";
            returnURL += "https://www.paypal.com/cgi-bin/webscr?cmd=cart&upload=1&business=services.huios@gmail.com";
            List<Item> cart = (List<Item>)Session["cart"];
            int i = 0;
            foreach (Item item in cart)
            {
                i++;
                returnURL += "&item_name_"+i+"=" + item.Pr.NomProduit;
                returnURL += "&item_number_" + i + "=" + i.ToString();
                returnURL += "&quantity_" + i + "=" + item.Quantity;
                returnURL += "&amount_" + i + "=" + item.Pr.prix;
            }
            //devise par défaut
            returnURL += "&currency=EUR";
            //URL de retour à la page précédente
            returnURL += "&return=http://www.google.com";
            //URL en cas d'annulation de la transaction
            returnURL += "&cancel_return=http://www.google.com";

            //vider la session Caddie
            Session.Remove("cart");

            return Redirect(returnURL);
        }
    }
}