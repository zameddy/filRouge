using PdfMvc.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PdfMvc.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>();
            for(int i=0;i<=10;i++)
            {
                Customer customer = new Customer
                {
                    CustomerId=i,
                    FirstName=string.Format("FirstName{0}",i.ToString()),
                    LastName=string.Format("LastName{0}", i.ToString())
                };
                customers.Add(customer);
            }
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PDF()
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i <= 10; i++)
            {
                Customer customer = new Customer
                {
                    CustomerId = i,
                    FirstName = string.Format("FirstName{0}", i.ToString()),
                    LastName = string.Format("LastName{0}", i.ToString())
                };
                customers.Add(customer);
            }
            //return new RazorPDF.PdfResult(customers, "PDF");
            return new ActionAsPdf("Index") { FileName = "Test.pdf" };
        }
    }
}
