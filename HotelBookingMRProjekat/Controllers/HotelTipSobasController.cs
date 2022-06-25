using HotelBookingMRProjekat.Models;
using HotelBookingMRProjekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using PagedList;

namespace HotelBookingMRProjekat.Controllers
{
    public class HotelTipSobasController : Controller
    {
        private ApplicationDbContext _context;


        public HotelTipSobasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
     
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
                return View("Index");
            
            
               return View("IndexKorisnici");
        }

        [Authorize(Roles = "Korisnik,Admin")]
        public ActionResult IndexBooking()
        {
            string userID = User.Identity.GetUserId();
    
            var bookingkorisnik = _context.BookingBaza.Where(h => h.ApplicationUserId.Contains(userID));

            
            bool result = User.IsInRole("Admin");

            if (result == true)
            {

                var booking = _context.BookingBaza.ToList();

                var viewModel = new HotelBookingSobaViewModel
                {
                    Bookingi = booking,
                    HotelSobe = _context.HotelSobaBaza.ToList(),
                    ApplicationUseri = _context.Users.ToList()

                };


                return View(viewModel);
            }
            

                var korisnikModel = new HotelBookingSobaViewModel
                {

                    BookingiKorisnici = bookingkorisnik,
                    HotelSobe = _context.HotelSobaBaza.ToList(),
                    ApplicationUseri = _context.Users.ToList()


                };

            return View("IndexBookingKorisnici", korisnikModel);
        }


        public ActionResult NoviBooking()
        {
            string userID = User.Identity.GetUserId();

            var bookingkorisnik = _context.BookingBaza.Where(h => h.ApplicationUserId.Contains(userID));


            bool result = User.IsInRole("Admin");

            if (result == true)
            {

                var booking = _context.BookingBaza.ToList();

                var viewModel = new HotelBookingSobaViewModel
                {
                    Bookingi = booking,
                    HotelSobe = _context.HotelSobaBaza.ToList(),
                    ApplicationUseri = _context.Users.ToList()

                };


                return View("BookingForma",viewModel);
            }


            var korisnikModel = new HotelBookingSobaViewModel
            {

                BookingiKorisnici = bookingkorisnik,
                HotelSobe = _context.HotelSobaBaza.ToList(),
                ApplicationUseri = _context.Users.ToList(),
                UserId = userID 

            };
         
            return View("BookingFormaKorisnik",korisnikModel);
        }


        public ActionResult NovaSoba()
        {
            var tipoviSobe = _context.HotelTipSobaBaza.ToList();
            var viewModel = new NovaSobaViewModel {
                HotelTipSobe = tipoviSobe
            };
            return View("SobaForma",viewModel);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult IndexTipovi(string Sorting_Order, string Search_Podaci, string Filter_Value, int? Page_No)
        {

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "NazivTipaSobe" : "";
            ViewBag.SortingPansion = String.IsNullOrEmpty(Sorting_Order) ? "PansionTipaSobe" : "";

            if (Search_Podaci != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Podaci = Filter_Value;
            }

            ViewBag.FilterValue = Search_Podaci;

            var tipovisobe = from tip in _context.HotelTipSobaBaza select tip;

            if (!String.IsNullOrEmpty(Search_Podaci))
            {
                tipovisobe = tipovisobe.Where(pretraga => pretraga.NazivTipaSobe.ToUpper().Contains(Search_Podaci.ToUpper())
                        || pretraga.PansionTipaSobe.ToUpper().Contains(Search_Podaci.ToUpper()));
            }
            switch (Sorting_Order)
            {
                case "NazivTipaSobe":
                    tipovisobe = tipovisobe.OrderByDescending(tip => tip.NazivTipaSobe);
                    break;
                case "PansionTipaSobe":
                    tipovisobe = tipovisobe.OrderBy(tip => tip.PansionTipaSobe);
                    break;
                default:
                    tipovisobe = tipovisobe.OrderBy(tip => tip.NazivTipaSobe);
                    break;
            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(tipovisobe.ToPagedList(No_Of_Page, Size_Of_Page));
          
        }

        [Authorize(Roles = "Admin")]
        public ActionResult NoviTipSobe()
        {
            var tipoviSobe = _context.HotelTipSobaBaza.ToList();
            var viewModel = new NovaSobaViewModel
            {
                HotelTipSobe = tipoviSobe
            };
            return View("TipSobeForma", viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ObrisiTipSobe(int id)
        {
            var hotelsoba = _context.HotelTipSobaBaza.Single(c => c.Id == id);
            if (hotelsoba == null)
                return HttpNotFound();

            _context.HotelTipSobaBaza.Remove(hotelsoba);
            _context.SaveChanges();
              
            return View("Uspesno");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SnimiSobu(HotelSoba hotelsoba)
        {
          
            if (hotelsoba.Id == 0)
            _context.HotelSobaBaza.Add(hotelsoba);
            else
            {
                var hotelSobaInDb = _context.HotelSobaBaza.Single(c => c.Id == hotelsoba.Id);

                hotelSobaInDb.Id = hotelsoba.Id;
                hotelSobaInDb.NazivSobe = hotelsoba.NazivSobe;
                hotelSobaInDb.CenaPoDanu = hotelsoba.CenaPoDanu;
                hotelSobaInDb.HotelTipSobaID = hotelsoba.HotelTipSobaID;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "HotelTipSobas");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SnimiBooking(BookingSoba bookingSoba)
        {
            if (bookingSoba.Id == 0)
                _context.BookingBaza.Add(bookingSoba);
            else
            {
                var hotelBookingInDb = _context.BookingBaza.Single(c => c.Id == bookingSoba.Id);

                hotelBookingInDb.Id = bookingSoba.Id;
                hotelBookingInDb.OstajanjeOd = bookingSoba.OstajanjeOd;
                hotelBookingInDb.OstajanjeDo = bookingSoba.OstajanjeDo;
                hotelBookingInDb.HotelSobaId = bookingSoba.HotelSobaId;
                hotelBookingInDb.ApplicationUserId = bookingSoba.ApplicationUserId;

            }
            _context.SaveChanges();

            return RedirectToAction("IndexBooking", "HotelTipSobas");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SnimiTipSobe(HotelTipSoba hotelTipSoba)
        {
            if (hotelTipSoba.Id == 0)
                _context.HotelTipSobaBaza.Add(hotelTipSoba);
            else
            {
                var hotelTipSobaInDb = _context.HotelTipSobaBaza.Single(c => c.Id == hotelTipSoba.Id);

                hotelTipSobaInDb.Id = hotelTipSoba.Id;
                hotelTipSobaInDb.NazivTipaSobe = hotelTipSoba.NazivTipaSobe;
                hotelTipSobaInDb.PansionTipaSobe = hotelTipSoba.PansionTipaSobe;
            
            }
            _context.SaveChanges();

            return RedirectToAction("IndexTipovi", "HotelTipSobas");
        }


        public ActionResult IzmeniBooking(int id)
        {
       
            string userID = User.Identity.GetUserId();

            var bookingkorisnik = _context.BookingBaza.Where(h => h.ApplicationUserId.Contains(userID)).SingleOrDefault(c => c.Id == id);

         
            bool result = User.IsInRole("Admin");

            if (result == true)
            {

               var booking = _context.BookingBaza.SingleOrDefault(c => c.Id == id);

                var viewModel = new HotelBookingSobaViewModel
                {
                    BookingSoba = booking,
                    HotelSobe = _context.HotelSobaBaza.ToList(),
                    ApplicationUseri = _context.Users.ToList()

                };


                return View("BookingForma", viewModel);
            }


            var korisnikModel = new HotelBookingSobaViewModel
            {

                BookingSoba = bookingkorisnik,
                HotelSobe = _context.HotelSobaBaza.ToList(),
                ApplicationUseri = _context.Users.ToList(),
                UserId = userID

            };

            return View("BookingFormaKorisnik", korisnikModel);

        }



        public ActionResult ObrisiBooking(int id)
        {

            var booking = _context.BookingBaza.SingleOrDefault(c => c.Id == id);

            if (booking == null)
                return HttpNotFound();

            _context.BookingBaza.Remove(booking);
            _context.SaveChanges();


            return View("Uspesno");
        }


        public ActionResult Izmeni(int id)
        {

            var hotelsoba = _context.HotelSobaBaza.SingleOrDefault(c => c.Id == id);
            if (hotelsoba == null)
                return HttpNotFound();

            var viewModel = new NovaSobaViewModel
            {
                HotelSoba = hotelsoba,
                HotelTipSobe = _context.HotelTipSobaBaza.ToList()
            };

            return View("SobaForma",viewModel);
        }

        public ActionResult IzmeniTipSobe(int id)
        {

            var hoteltipsoba = _context.HotelTipSobaBaza.SingleOrDefault(c => c.Id == id);
            if (hoteltipsoba == null)
                return HttpNotFound();

            var viewModel = new NovaSobaViewModel
            {
                HotelTipSoba = hoteltipsoba
            };

            return View("TipSobeForma", viewModel);
        }
       [AllowAnonymous]
        public ActionResult Detalji(int id)
        {
     
            var viewModel = new NovaSobaViewModel
            {
                HotelSoba = _context.HotelSobaBaza.SingleOrDefault(c => c.Id == id),
                FotografijesViewModel = _context.HotelFotografijeBaza.Where(c => c.HotelSobaId == id).ToList()
              };

            if (viewModel == null)
                return HttpNotFound();

            return View(viewModel);
        }

    }
}