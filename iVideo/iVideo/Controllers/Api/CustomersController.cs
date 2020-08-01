using AutoMapper;
using iVideo.Dtos;
using iVideo.Models;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iVideo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }

        // api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        //  api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //POST api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created( new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        //PUT api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }


        // DELETE api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult MarkCustomerAsDeliquent(int id,bool status)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id==id);
            if (customerInDb == null)
                return NotFound();
            customerInDb.IsDeliquent = status;

            _context.SaveChanges();

            return Ok();
        }
    }
}
