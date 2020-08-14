using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iVideo.Dtos
{
    public class CustomerEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}