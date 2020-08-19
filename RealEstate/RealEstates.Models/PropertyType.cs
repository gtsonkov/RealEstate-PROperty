﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class PropertyType
    {
        public PropertyType()
        {
            this.Properties = new HashSet<RealEstateProperty>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<RealEstateProperty> Properties { get; set; }
    }
}