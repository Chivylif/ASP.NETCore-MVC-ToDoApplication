using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApplication.Models;
using ToDoApplication.Services;

namespace ToDoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToDoService _todoServices;

        public HomeController(ILogger<HomeController> logger, IToDoService todoServices)
        {
            _logger = logger;
            _todoServices = todoServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _todoServices.AllList;
            return View(data);
        }

        [HttpGet]
        public ViewResult NotFoundPage()
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