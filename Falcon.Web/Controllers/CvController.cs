using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.Data;
using Falcon.Domain.Models;
using Falcon.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Falcon.Web.Controllers
{
    public class CvController : Controller
    {
        FalconService falconService = new FalconService();
        public MembersManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<MembersManager>();
            }
        }
        // GET: Cv
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cv/Create
        [HttpPost]
        public ActionResult Create(CV model, HttpPostedFileBase mypdf)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var freelancer = falconService.GetFreelancerById(User.Identity.GetUserId<int>());
            string savePath = "~/Content/Falcon/PDF";
            string fileName = mypdf.FileName;
            var doc = new Document
            {
                path = mypdf.FileName
            };
            falconService.AddCv(freelancer,model);
            return RedirectToAction("Index");
        }

        // GET: Cv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cv/Edit/5
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

        // GET: Cv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cv/Delete/5
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
