using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.Data;
using Falcon.Domain.Models;
using Falcon.Service;
using Falcon.Web.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Member = Falcon.Domain.Models.Member;

namespace Falcon.Web.Controllers
{
    public class FreelancerController : Controller
    {
        FalconService falconService = new FalconService();
        public MembersManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<MembersManager>();
            }
        }
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

        [Authorize]
        // GET: Freelancer/Create
        public ActionResult Create()
        {
            var c = falconService.GetFreelancerById(User.Identity.GetUserId<int>());
            if (c != null)
                return RedirectToAction("Create", "CV");
            ViewBag.random = FalconUtils.GetRandomFreelancer();
            return View();
        }

        // POST: Freelancer/Create
        [HttpPost]
        public ActionResult Create(FreelancerProfileViewModel model, HttpPostedFileBase profilepic)
        {
            var random = FalconUtils.GetRandomFreelancer();
           if (!ModelState.IsValid)
            {
                return View(model);
            }
            var freelancer = new Freelancer
            {
                idMember = User.Identity.GetUserId<int>()
            };
            Document doc = null;
            if (profilepic != null)
            {
                const string temppath = @"D:\Temp\";
                string filename = "profile_" + User.Identity.Name + ".png";
                var path = temppath + filename;
                if (System.IO.File.Exists(temppath + filename))
                {
                    System.IO.File.Delete(path);
                }
                profilepic.SaveAs(path);
                FalconUtils.UploadToFtp("/Freelancers/Pics/", path);
                doc = new Document
                {
                    path = "/Freelancers/Pics/" + filename,
                    type = "profilepic"
                };
            }
           
            var current = UserManager.FindById(User.Identity.GetUserId<int>());
            current.firstname = model.Firstname;
            current.lastname = model.Lastname;
            current.country = model.Address;
            current.city = model.City;
            current.role = "Freelancer";
            current.Document = doc;
            UserManager.AddToRole(User.Identity.GetUserId<int>(), "Freelancer");
            UserManager.Update(current);
            falconService.UnitOfWork.Commit();
            falconService.AddFreelancer(freelancer);
            return RedirectToAction("Create", "CV");
            
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
