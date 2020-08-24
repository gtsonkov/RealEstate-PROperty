using Microsoft.AspNetCore.Mvc;
using RealEstates.Services.Contracts;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private IPropertiesService _propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this._propertiesService = propertiesService;
        }

        public IActionResult Search()
        {
            return this.View();
        }

        public IActionResult DoSearch(int minPrice, int maxPrice)
        {
            var result = this._propertiesService.SearchByPrice(minPrice, maxPrice);

            return this.View(result);
        }
    }
}