using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;

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
            return View();
        }
        public PartialViewResult GetHomeIndexTable()
        {
            var model = new List<HomeIndexDTO>();

            for (int i = 0; i < 10; i++)
            {
                HomeIndexDTO homeIndexDTO = new HomeIndexDTO()
                {
                    Id = i,
                    Name = "Test" + i
                };
                model.Add(homeIndexDTO);
            }

            return PartialView("~/Views/partialViews/_homeindexpartialview.cshtml", model);
        }
        public JsonResult AddHesapKartTip([FromForm] HomeIndexDTO homeIndexDTO)
        {
            Object result;
            if (homeIndexDTO.Name == null || homeIndexDTO.Name == "")
                result = new { result = false };
            else
                result = new { result = true };

           return Json(result);
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