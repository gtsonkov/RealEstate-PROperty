using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.Linq;

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


            #region District
            //Distrinct

            var currDistrict = this._db.Districts
                                        .FirstOrDefault(x => x.Name.Trim() == distinct.Trim());

            if (currDistrict == null)
            {
                currDistrict = new District
                {
                    Name = distinct,
                };
            }

            property.District = currDistrict;
            #endregion

            #region BuildingType
            //Building

            var currBuildingType = this._db.BuildingTypes
                                            .FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());

            if (currBuildingType == null)
            {
                currBuildingType = new BuildingType
                {
                    Name = buildingType
                };
            }

            property.BuildingType = currBuildingType;
            #endregion

            #region PropertyType
            //PropertyTupe

            var currPropertyType = this._db.PropertyTypes
                                    .FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());

            if (currPropertyType == null)
            {
                currPropertyType = new PropertyType
                {
                    Name = propertyType
                };
            }

            property.PropertyType = currPropertyType;
            #endregion

            this._db.Add(property);
            this._db.SaveChanges();
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize) => throw new System.NotImplementedException();

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice) => throw new System.NotImplementedException();
        public void UpdateTags(int propertyId) => throw new System.NotImplementedException();
    }
}