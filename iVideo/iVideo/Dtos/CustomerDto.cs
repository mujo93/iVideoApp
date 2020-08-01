using iVideo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iVideo.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Is Deliquent")]
        public bool IsDeliquent { get; set; }
    }
}