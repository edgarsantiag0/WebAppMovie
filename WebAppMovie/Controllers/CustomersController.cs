﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebAppMovie.Models;
using WebAppMovie.ViewModels;

namespace WebAppMovie.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); // libera los recursos
        }

        // GET: Customers
        //[OutputCache(Duration = 50)]
        [Authorize]
        public ActionResult Index()
        {
            var model = GetCustomers();

            if (User.IsInRole("CanManageCustomers"))
            {
                return View("Index", model);
            }

            return View("IndexReadOnly", model);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList(); 
        }

        [Authorize(Roles = RoleName.CanManageCustomers)] 
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // El form envia un NewCustomerViewModel
        // Pero MVC hace el binding a Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Prueba()
        {

            var model = new CustomerViewModel();
            model.Name = "Name 1";
            model.LastName = "LastName 1";


            var movie1 = new Movie();
            movie1.Id = 1;
            movie1.Name = "Star Wars";


            var movie2 = new Movie();
            movie1.Id = 2;
            movie1.Name = "Advengers";


            model.Movies.Add(movie1);
            model.Movies.Add(movie2);



            return View(model);
        }





        //public ActionResult Details(int id)
        //{
        //    ViewBag.Nombre = "Cordero";
        //    ViewBag.Edad = 27;
        //    ViewBag.Id = id;

        //    List<string> peliculas = new List<string>()
        //    {
        //        "Star wars",
        //        "Spider Man",
        //        "James Bond",
        //        "NUeva movie"
        //    };

        //    ViewBag.PeliculasEnMano = peliculas;


        //    return View();
        //}

        //Details/id
        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            // _context.Customers.Find(id)



            if (customer == null)
                return HttpNotFound();
           

            return View(customer);
        }
    }
}