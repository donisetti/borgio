using System.Web.Mvc;

namespace SuperBorgio.GestorWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {


        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.Versao = "1.00.3 - 16/04/2015 10:30 ]";

            //ViewBag.Extenso = Extenso.ToExtenso(245765.32, Extenso.TipoValorExtenso.Monetario);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}