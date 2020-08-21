using RealEstates.Data;
using RealEstates.Models;
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

        public void Create(int size, int? floor, int? maxFloorCount, string distinct, string propertyType, string buildingType, int? year, int price)
        {
            var property = new RealEstateProperty
            {
                Size = size,
                Price = price,
                Year = year,
                Floor = floor,
                TotalNumberOfFloors = maxFloorCount
            };

            if (year <= 0)
            {
                property.Year = null;
            }

            if (floor == 0)
            {
                property.Floor = null;
            }

            if (maxFloorCount == 0)
            {
                property.TotalNumberOfFloors = null;
            }
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize) => throw new System.NotImplementedException();

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice) => throw new System.NotImplementedException();
    }
}