using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using moviewatch.Models;

namespace moviewatch.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShip);
            if (customers == null)
            {
                return RedirectToAction("CustomerForm");
            }
            return View();
        }

        public ActionResult CustomerForm()
        {
            var membership = _context.Membership.ToList();
            var viewmodel = new CustomerViewModel
            {
                Membership = membership
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customermodel = new CustomerViewModel
                {
                    Customer = customer,
                    Membership = _context.Membership.ToList()
                    
                };
                return View("CustomerForm", customermodel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerDB.Name = customer.Name;
                customerDB.DOB = customer.DOB;
                customerDB.MemberShipId = customer.MemberShipId;
                customerDB.IsSubscribedNewsletter = customer.IsSubscribedNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult DispCustomer(int id) {
            var customer = _context.Customers.Include(c => c.MemberShip).SingleOrDefault(c => c.Id==id);
            if (customer == null)
                return HttpNotFound();
            var customermodel = new CustomerViewModel
            {
                Customer = customer,
                Membership = _context.Membership.ToList()
            };
            return View("CustomerForm",customermodel);

         }
    }
}