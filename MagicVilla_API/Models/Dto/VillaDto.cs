﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDto
    {   
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Required]
        public double Price { get; set; }

        public int Occupants { get; set; }

        public int SquareMeter { get; set; }
        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

        
    }
}
