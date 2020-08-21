using RealEstates.Services.Models;
using RealEstates.Common.Constants;
using System.Collections.Generic;

namespace RealEstates.Services.Contracts
{
    public interface IDistrictService
    {
        public IEnumerable<DistrictVievModel> GetTopDistrictsByAveragePrice(int count = Constants.DistinctsCount);

        public IEnumerable<DistrictVievModel> GetTopDistrictsNumberOfProperties(int count = Constants.DistinctsCount);
    }
}