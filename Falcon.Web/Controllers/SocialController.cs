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
using Microsoft.SqlServer.Server;

namespace Falcon.Web.Controllers
{
    public class SocialController : Controller
    {
        FalconService falconService = new FalconService();
        public MembersManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<MembersManager>();
            }
        }
        // GET: Social
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Timeline()
        {
            var freelancer = falconService.GetFreelancerById(User.Identity.GetUserId<int>());
            return View(freelancer);
        }

        public ActionResult Messages()
        {
            var freelancer = falconService.GetFreelancerById(User.Identity.GetUserId<int>());
            return View(freelancer);
        }

        public ActionResult PublicProfile(int id)
        {
            var freelancer = falconService.GetFreelancerById(id);
            return View(freelancer);
        }

        public ActionResult SendMessage(int idsender,int idreceiver,string body)
        {
            var sender = falconService.GetFreelancerById(idsender);
            var receiver = falconService.GetFreelancerById(idreceiver);
            var pm = new PrivateMessage
            {
                sender_fk = idsender,
                receiver_fk = idreceiver,
                body = body,
                date = DateTime.Now

            };
            falconService.UnitOfWork.PrivateMessageRepository.Add(pm);
            falconService.UnitOfWork.Commit();
            return Json(data:"success");
        }
    }
}