using System.Linq;
using System.Web.Mvc;
using Falcon.Service;

namespace Falcon.Web.Controllers
{
    public class HomeController : Controller
    {
        FalconService falconService = new FalconService();
        public ActionResult Index()
        {
            ViewBag.missions = falconService.UnitOfWork.MissionRepository.GetAll().Take(5).ToList();
            var freelancers = falconService.UnitOfWork.FreelancerRepository.GetAll().Take(5).ToList();
            ViewBag.owners = falconService.UnitOfWork.OwnerRepository.GetAll().Take(2).ToList();
            ViewBag.categories = falconService.GetCategories();
            return View(freelancers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}