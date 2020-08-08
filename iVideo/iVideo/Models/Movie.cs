using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace iVideo.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a movie name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name="Release Date")]
        
        public DateTime? ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
        [Display(Name="Number in Stock")]
        
        [Range(1,20,ErrorMessage ="Value must be between 1,20")]
        public int? NumberInStock { get; set; }
        public Genre Genre { get; set; }
        
        [Display(Name="Genre")]
        [Required]
        public int GenreId { get; set; }
        
        public byte NumberAvailable { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}