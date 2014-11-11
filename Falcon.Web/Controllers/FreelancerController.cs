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

        // GET: Freelancer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Freelancer/Create
        [HttpPost]
        public ActionResult Create(FreelancerProfileViewModel model)
        {
           if (!ModelState.IsValid)
            {
                return View(model);
            }
            var current = UserManager.Users.First(u => u.idMember.Equals(User.Identity.GetUserId<int>()));
            var freelancer = new Freelancer
            {
                Member = current
            };
            falconService.AddFreelancer(freelancer);
            return RedirectToAction("Index");
            
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
