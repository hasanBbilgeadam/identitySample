using ıdentitySample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestLayer.Services;

namespace ıdentitySample.Controllers
{
    public class HomeController : Controller
    {

      private readonly ICustomService _service;
      private readonly ICustomService2 _service2;

        public HomeController(ICustomService service, ICustomService2 service2)
        {
            _service = service;
            _service2 = service2;
        }

        public IActionResult Index()
        {

            _service.SayHello();
            _service2.SayHello();
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