using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required(ErrorMessage ="Description is must")]
        public string? Descripton { get; set; }
        [Display(Name ="Price per night")]
        [Required(ErrorMessage ="Please enter price")]
        [Range(10,1000)]
        public double Price { get; set; }
        [Required(ErrorMessage ="Size should be in square feet")]
        public int Sqft { get; set; }
        [Required(ErrorMessage ="occupancy must be greater than 0")]
        [Range(1,10)]
        public int Occupancy { get; set; }
        [Display(Name = "Property's Image Url")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
