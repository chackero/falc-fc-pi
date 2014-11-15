using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Falcon.Data;
using Falcon.Domain.Models;
using Falcon.Service;
using Falcon.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Falcon.Web.Controllers
{
    public class OwnerController : Controller
    {
        FalconService falconService = new FalconService();
        public MembersManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<MembersManager>();
            }
        }
        // GET: Owner
        public ActionResult Index()
        {
            return View();
        }

        // GET: Owner/Details/5
        public ActionResult Details(int id)
        {

            return View(falconService.GetOwnerById(id));
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(OwnerProfileViewModel model, HttpPostedFileBase complogo)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var owner = new Owner
            {
                idMember = User.Identity.GetUserId<int>(),
                companyName = model.CompanyName,
                companyDescription = model.CompanyDescription
            };
            Document doc = null;
            if (complogo != null)
            {
                const string temppath = @"D:\Temp\";
                string filename = "profile_" + User.Identity.Name + ".png";
                var path = temppath + filename;
                if (System.IO.File.Exists(temppath + filename))
                {
                    System.IO.File.Delete(path);
                }
                complogo.SaveAs(path);
                FalconUtils.UploadToFtp("/Owners/Logos/", path);
                doc = new Document
                {
                    path = "/Owners/Logos/" + filename,
                    type = "logo"
                };
            }
            var current = UserManager.FindById(User.Identity.GetUserId<int>());
            current.city = model.CompanyAddress;
            current.firstname = model.CompanyName;
            current.country = model.Website;
            current.role = "Owner";
            current.Document = doc;
            //UserManager.AddToRole(User.Identity.GetUserId<int>(), "Owner");
            UserManager.Update(current);
            falconService.UnitOfWork.Commit();
            if (current.Document != null) owner.c_logo_fk = current.Document.idDocument;
            falconService.AddOwner(owner);

            return RedirectToAction("Details", new { id = User.Identity.GetUserId<int>() });
        }

        // GET: Owner/Edit/5
        public ActionResult Edit()
        {
            var owner = falconService.GetOwnerById(User.Identity.GetUserId<int>());
            return View(owner);
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(FormCollection collection, Owner model, HttpPostedFileBase editedlogo)
        {
            var owner = falconService.GetOwnerById(User.Identity.GetUserId<int>());
            var member = UserManager.FindById(User.Identity.GetUserId<int>());
            if (collection["oldpass"].Length > 0)
            {
                var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId<int>(), collection["oldpass"],
                    collection["newpassword"]);
                if (!result.Succeeded)
                {
                    return View(model);
                }
            }
            Document doc = null;
            if (editedlogo != null)
            {
                const string temppath = @"D:\Temp\";
                string filename = "profile_" + User.Identity.Name + ".png";
                var path = temppath + filename;
                if (System.IO.File.Exists(temppath + filename))
                {
                    System.IO.File.Delete(path);
                }
                editedlogo.SaveAs(path);
                FalconUtils.UploadToFtp("/Owners/Logos/", path);
                if (owner.Document == null)
                {
                    doc = new Document
                    {
                        path = "/Owners/Logos/" + filename,
                        type = "logo"
                    };
                    owner.Document = doc;
                }
            }
            owner.companyName = model.companyName;
            owner.companyDescription = model.companyDescription;
            UserManager.Update(member);
            falconService.UnitOfWork.Commit();
            falconService.EditOwner(owner);
            return RedirectToAction("Details", new {id=owner.idMember});
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Owner/Delete/5
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
