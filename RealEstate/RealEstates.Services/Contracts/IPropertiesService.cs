using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services.Contracts
{
    public interface IPropertiesService
    {
        public void Create(int seize, int? floor, int? maxFloorCount, string distinct, string propertyType, string buildingType, int? year, int price);

        public void UpdateTags(int propertyId);

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize);

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice);
    }
}