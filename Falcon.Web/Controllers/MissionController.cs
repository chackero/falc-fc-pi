﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Falcon.Service;

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
            return View();
        }

        // POST: Mission/Create
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

        // GET: Mission/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mission/Edit/5
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