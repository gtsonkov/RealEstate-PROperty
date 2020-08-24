using RealEstates.Common.Constants;
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
    public class DistrictService : IDistrictService
    {
        private RealEstateDbContext _db;

        public DistrictService(RealEstateDbContext db)
        {
            this._db = db;
        }

        public IEnumerable<DistrictVievModel> GetTopDistrictsByAveragePrice(int count = Constants.DistinctsCount)
        {
            return this._db.Districts
                .OrderByDescending(d => d.Properties.Average(p => p.Price))
                .Select(MapDistrictViewModel())
                .Take(count)
                .ToList();
        }

        public IEnumerable<DistrictVievModel> GetTopDistrictsNumberOfProperties(int count = Constants.DistinctsCount)
        {
            return this._db.Districts
                .OrderByDescending(d => d.Properties.Count)
                .Select(MapDistrictViewModel())
                .Take(count)
                .ToList();
        }

        private static Expression<Func<District, DistrictVievModel>> MapDistrictViewModel()
        {
            return d => new DistrictVievModel
            {
                Name = d.Name,
                AveragePrice = d.Properties.Average(p => p.Price),
                MaxPrice = d.Properties.Max(p => p.Price),
                MinPrice = d.Properties.Min(p => p.Price),
                PropertiesCount = d.Properties.Count
            };
        }
    }
}