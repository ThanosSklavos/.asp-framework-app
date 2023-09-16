using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationNetFramework.Models;

namespace WebApplicationNetFramework.Controllers
{

    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        public ActionResult Index() 
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]   //Model Binding
        public ActionResult Create(Customer customer)
        {
            int membershipTypeId = customer.MembershipTypeId;

            var membershipType = _context.MembershipTypes.FirstOrDefault( m => m.Id == membershipTypeId );
            customer.MembershipType = membershipType;
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

/*        // GET: Customers
        [Route("customers/GetCustomers")]
        public ActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }*/
/*
        [Route("customers/Details")]*/
        public ActionResult Details(int id) 
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}