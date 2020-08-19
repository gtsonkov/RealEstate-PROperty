using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class Tag
    {
        public Tag()
        {
            this.RealEstateProperties = new HashSet<RealEstateTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RealEstateTag> RealEstateProperties { get; set; }
    }
}