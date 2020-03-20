using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;   
using System.Web;
using System.Web.Mvc;
using VIdly.Models;
using VIdly.ViewModels;

namespace VIdly.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //var customers = new list<customer>
            //{
            //    new customer{id = 1,name = "william edward"},
            //    new customer{id=2 , name = "carl smith"}
            //};
            return View();
        }
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            //var customers = new List<Customer>
            //{
            //    new Customer{id = 1,Name = "William Edward"},
            //    new Customer{id = 2 , Name = "carl smith"}
            //};
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.id == id);
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                     MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("customerForm", viewModel);
            }
            if (customer.id == 0)
                    
                     _context.Customers.Add(customer);
            else
            {
                var CustomerInDB = _context.Customers.Single(c => c.id == customer.id);
                CustomerInDB.Name = customer.Name;
                CustomerInDB.Birthdate = customer.Birthdate;
                CustomerInDB.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
                CustomerInDB.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }

    
}