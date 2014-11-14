using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Falcon.Domain.Models;
using Falcon.Service;
using Falcon.Web.Models;
using Microsoft.AspNet.Identity;

namespace Falcon.Web.Controllers
{
    public class MissionController : Controller
    {
        FalconService falconService = new FalconService();
        // GET: Mission
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mission/Details/5
        public ActionResult Details(int id)
        {
            var mission = falconService.getMissionById(id);
            return View(mission);
        }

        // GET: Mission/Create
        public ActionResult Create()
        {
            var m = falconService.GetCategories();

            ViewBag.Category = m;
            return View();
        }

        // POST: Mission/Create
        [HttpPost]
        public ActionResult Create(FormCollection formCollection,CreateMissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Create(formCollection, model);
            }
            int cid = falconService.GetCategoryByName(formCollection["category"]).idCategory;
            var mission = new Mission
            {
                owner_fk = User.Identity.GetUserId<int>(),
                title = model.Title,
                budget = model.Budget,
                description = model.Description,
                plannedStart = model.plannedStart,
                duration = model.duration,
                postDate = DateTime.Now,
                status = "active",
                deadline = model.deadline,
                category_idCategory = cid
            };
            falconService.AddMission(mission);
            return RedirectToAction("Details",new {id=mission.idMission});
        }

        // GET: Mission/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission p = falconService.getMissionById(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: Mission/Edit/5
        [HttpPost]
        public ActionResult Edit(Mission model,int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                int idc = falconService.GetCategoryByName(model.Category.name).idCategory;
                model.category_idCategory = idc;
                model.Category = falconService.GetCategoryById(idc);
                model.idMission = id;
                model.owner_fk = falconService.getMissionById(id).owner_fk;
                model.status = falconService.getMissionById(id).status;
                falconService.EditMission(model);

                return RedirectToAction("Details",new {id=model.idMission});
            }
            return View(model);
        }

        // GET: Mission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mission/Delete/5
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
