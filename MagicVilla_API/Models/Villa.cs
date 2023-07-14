using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public int Occupants { get; set; }

        public int SquareMeter { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }


    }
}
