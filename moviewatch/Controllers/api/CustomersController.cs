using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using moviewatch.Models;
using moviewatch.App_Start;
using moviewatch.DTO;
using AutoMapper;
using System.Data.Entity;

namespace moviewatch.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        // GET /api/customers
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers/1
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.Include(c => c.MemberShip).ToList().Select(Mapper.Map<Customer,CustomerDTO>));
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id==id);
            if (customer == null)
                return NotFound();
            else
            {
                return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
            }
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDTO.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDTO);
            }
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customers == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map(customerDTO, customers);
                    _context.SaveChanges();
                }
            }
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customers);                
                _context.SaveChanges();
            }
        }
    }
}
