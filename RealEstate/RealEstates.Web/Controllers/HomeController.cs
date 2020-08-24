using Microsoft.AspNetCore.Mvc;
using RealEstates.Services.Contracts;
using RealEstates.Web.Models;
using System.Diagnostics;

namespace RealEstates.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistrictService _districtService;

        public HomeController(IDistrictService districtService)
        {
            this._districtService = districtService;
        }

        public IActionResult Index()
        {
            var districts = this._districtService.GetTopDistrictsByAveragePrice();

            return View(districts);
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