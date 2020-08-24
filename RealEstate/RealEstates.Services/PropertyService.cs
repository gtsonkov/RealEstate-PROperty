using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RealEstates.Services
{
    public class PropertyService : IPropertiesService
    {
        private readonly RealEstateDbContext _db;
        private readonly List<District> _districts;
        private readonly List<BuildingType> _buildingTypes;
        private readonly List<PropertyType> _propertyTypes;

        public PropertyService(RealEstateDbContext dbContext)
        {
            this._db = dbContext;
            this._districts = new List<District>();
            this._buildingTypes = new List<BuildingType>();
            this._propertyTypes = new List<PropertyType>();
        }

        public void Create(int size, int? floor, int? maxFloorCount, string district, string propertyType, string buildingType, int? year, int price)
        {
            if (district == null)
            {
                return;
            }

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

            var currDistrict = this._districts.FirstOrDefault(x => x.Name == district);

            if (currDistrict == null)
            {
                currDistrict = new District
                {
                    Name = district,
                };

                this._districts.Add(currDistrict);
            }

            property.District = currDistrict;
            #endregion

            #region BuildingType
            //Building

            var currBuildingType = this._buildingTypes
                                            .FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());

            if (currBuildingType == null)
            {
                currBuildingType = new BuildingType
                {
                    Name = buildingType
                };

                this._buildingTypes.Add(currBuildingType);
            }

            property.BuildingType = currBuildingType;
            #endregion

            #region PropertyType
            //PropertyTupe

            var currPropertyType = this._propertyTypes
                                    .FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());

            if (currPropertyType == null)
            {
                currPropertyType = new PropertyType
                {
                    Name = propertyType
                };

                this._propertyTypes.Add(currPropertyType);
            }

            property.PropertyType = currPropertyType;
            #endregion

            this._db.Add(property);
        }

        public void SaveChanges()
        {
            this._db.SaveChanges();
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int maxSize)
        {
            return _db.RealEstateProperties
               .Where(rp => rp.Year >= minYear && rp.Year <= maxYear && rp.Size >= minSize && rp.Size <= maxSize)
               .Select(MapPropertyView())
               .OrderBy(x => x.Year)
               .ThenBy(x => x.Size)
               .ToList();
        }

        public IEnumerable<PropertyViewModel> SearchByPrice(int minPrice, int maxPrice)
        {
            return this._db.RealEstateProperties.Where(rp => rp.Price >= minPrice && rp.Price <= maxPrice)
                .Select(MapPropertyView())
                .OrderBy(x => x.Price)
                .ToList();
        }

        public void UpdateTags(int propertyId)
        {
            var currProperty = this._db.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);

            if (currProperty == null)
            {
                throw new ArgumentException("No tag found with given Id");
            }

            currProperty.Tags.Clear();

            if (currProperty.Year < 1990)
            {
                currProperty.Tags.Add(new RealEstateTag
                {
                    Tag = GetOrCreateTag("OldBuilding")
                });
            }

            if (currProperty.Size > 120)
            {
                currProperty.Tags.Add(new RealEstateTag
                {
                    Tag = GetOrCreateTag("HugeProperty")
                });
            }

            if (currProperty.Floor == currProperty.TotalNumberOfFloors)
            {
                currProperty.Tags.Add(new RealEstateTag
                {
                    Tag = GetOrCreateTag("LastFloor")
                });
            }

            this._db.SaveChanges();
        }

        private Tag GetOrCreateTag(string name)
        {
            var currTag = this._db.Tags.FirstOrDefault(x => x.Name.Trim() == name.Trim());

            if (currTag == null )
            {
                currTag = new Tag
                {
                    Name = name
                };
            }

            return currTag;
        }

        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapPropertyView()
        {
            return x =>  new PropertyViewModel()
            {
                BuildingType = x.BuildingType.Name,
                District = x.District.Name,
                Floor = (x.Floor ?? 0).ToString() + "/" + (x.TotalNumberOfFloors ?? 0).ToString(),
                Price = x.Price,
                Size = x.Size,
                Year = x.Year,
                PropertyType = x.PropertyType.Name
            };
        }
    }
}