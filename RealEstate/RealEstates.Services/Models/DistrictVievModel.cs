namespace RealEstates.Services.Models
{
    public class DistrictVievModel
    {
        public string Name { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public int PropertiesCount { get; set; }

        public double AveragePrice { get; set; }
    }
}