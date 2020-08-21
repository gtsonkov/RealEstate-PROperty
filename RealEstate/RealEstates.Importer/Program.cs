using Newtonsoft.Json;
using RealEstates.Data;
using RealEstates.Importer.DTOs;
using RealEstates.Models;
using RealEstates.Services;
using RealEstates.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText(@"./ImportData/imot.bg-raw-data-2020-07-23.json");

            List<PropertyDTO> properties = JsonConvert
                .DeserializeObject<List<PropertyDTO>>(data);
            RealEstateDbContext db = new RealEstateDbContext();

            IPropertiesService propService = new PropertyService(db);

            foreach (var prop in properties)
            {
                propService.Create(
                    prop.Size,
                    prop.Floor,
                    prop.TotalFloors,
                    prop.District,
                    prop.Type,
                    prop.BuildingType,
                    prop.Year,
                    prop.Price
                    );
            }

            propService.SaveChanges();
        }
    }
}