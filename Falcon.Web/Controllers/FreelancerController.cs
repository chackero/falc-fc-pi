using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.Service;
using Microsoft.Ajax.Utilities;

namespace Falcon.Web.Controllers
{
    public class FreelancerController : Controller
    {
        FalconService falconService = new FalconService();
        // GET: Freelancer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Freelancer/Details/5
        public ActionResult Details(int id)
        {
            var freelancer = falconService.GetFreelancerById(id);
            return View(freelancer);
        }

        // GET: Freelancer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Freelancer/Create
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

        // GET: Freelancer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Freelancer/Edit/5
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

        // GET: Freelancer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Freelancer/Delete/5
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
    }
}
