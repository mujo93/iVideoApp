using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iVideo.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberInStock { get; set; }
        public int GenreId { get; set; }

        public int NumberAvailable { get; set; }
        public GenreDto Genre { get; set; }

        [Required]
        [Range(0,1000)]
        public decimal Price { get; set; }
    }
}