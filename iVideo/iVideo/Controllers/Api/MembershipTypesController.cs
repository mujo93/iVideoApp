using iVideo.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iVideo.Controllers.Api
{
    public class MembershipTypesController : ApiController
    {
        private ApplicationDbContext _context;
        public MembershipTypesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult Get()
        {
            var membershipTypes= _context.MembershipTypes.ToList();
            return Ok(membershipTypes);
        }
    }
}
