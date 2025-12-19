using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using WebApplication3.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<DBSelectOutClass> list = new DBManager().AllUserSelect();
            return View(model:list);
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
