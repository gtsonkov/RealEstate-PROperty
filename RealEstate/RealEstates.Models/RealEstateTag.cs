using System.Collections.Generic;

namespace RealEstates.Models
{
    public class RealEstateTag
    {
        public int RealEstateId { get; set; }

        public virtual RealEstateProperty RealEstate { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}