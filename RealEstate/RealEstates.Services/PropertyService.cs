using RealEstates.Data;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services
{
    public class PropertyService : IPropertiesService
    {
        private RealEstateDbContext _db;

        public PropertyService(RealEstateDbContext dbContext)
        {
            this._db = dbContext;
        }

        public void Create(int seize, int floor, int maxFloorCount, string distinct, string propertyType, string buildingType, int year, int price) => throw new System.NotImplementedException();
        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize) => throw new System.NotImplementedException();
        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice) => throw new System.NotImplementedException();
    }
}