using iVideo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iVideo.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}