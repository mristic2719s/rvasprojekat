using HotelBookingMRProjekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HotelBookingMRProjekat.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;


        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
        
            return View(_context.HotelFotografijeBaza.Include(c => c.HotelSoba).ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}