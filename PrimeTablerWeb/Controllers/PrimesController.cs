using System.Web.Mvc;
using PrimeTabler.PrimeTablerModel;

namespace PrimeTablerWeb.Controllers
{
    public class PrimesController : Controller
    {
        public ActionResult Index(int? id)
        {
            return View(new PrimesModel(id ?? 0));
        }
    }
}