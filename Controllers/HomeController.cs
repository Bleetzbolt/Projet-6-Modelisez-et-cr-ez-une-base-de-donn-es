using Microsoft.AspNetCore.Mvc;
using Projet_6_Modelisez_et_créez_une_base_de_données.Models;
using System.Diagnostics;

namespace Projet_6_Modelisez_et_créez_une_base_de_données.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
