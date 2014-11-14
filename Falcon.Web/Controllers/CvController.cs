using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Falcon.Data;
using Falcon.Domain.Models;
using Falcon.Service;
using Falcon.Web.Models;
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
            return RedirectToAction("Details","Freelancer",new {id});
        }

        // GET: Cv/Create
        public ActionResult Create()
        {
            var c = falconService.GetFreelancerById(User.Identity.GetUserId<int>()).CV;
            if (c != null)
                return RedirectToAction("Details", "Freelancer",new {id=User.Identity.GetUserId<int>()});

            ViewBag.user = UserManager.FindById(User.Identity.GetUserId<int>());
            ViewBag.random = FalconUtils.GetRandomFreelancer();
            return View();
        }

        // POST: Cv/Create
        [HttpPost]
        public ActionResult Create(CV model, HttpPostedFileBase mypdf)
        {
            if (!ModelState.IsValid || mypdf.ContentLength == 0)
            {
                return View(model);
            }

            var freelancer = falconService.GetFreelancerById(User.Identity.GetUserId<int>());
            if (mypdf != null)
            {
                var filename = "cv_" + User.Identity.Name + ".pdf";
                string path = @"D:\Temp\";
                mypdf.SaveAs(path + filename);
                FalconUtils.UploadToFtp("/Freelancers/Cvs/", path + filename);
                var doc = new Document
                {
                    path = "/Freelancers/Cvs/" + filename,
                    type = "pdf"
                };
                model.Document = doc;
            }
            falconService.AddCv(freelancer,model);
            return RedirectToAction("Details", "Freelancer", new { id = User.Identity.GetUserId<int>() });
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
