using RealEstates.Common.Constants;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services
{
    public class DistrictService : IDistrictService
    {
        public IEnumerable<DistrictVievModel> GetTopDistrictsByAveragePrice(int count = Constants.DistinctsCount) => throw new System.NotImplementedException();

        public IEnumerable<DistrictVievModel> GetTopDistrictsNumberOfProperties() => throw new System.NotImplementedException();
    }
}