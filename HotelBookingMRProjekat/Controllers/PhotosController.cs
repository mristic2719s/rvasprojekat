using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HotelBookingMRProjekat.Models;
using System.Data.Entity;
using HotelBookingMRProjekat.ViewModels;

namespace HotelBookingMRProjekat.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PhotosController : Controller
    {

        private ApplicationDbContext _context;


        public PhotosController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Home
        public ActionResult Index()
        {

            var viewModel = new PhotosViewModel
            {
                
               HotelSobe =  _context.HotelSobaBaza.ToList(),
               Photos = _context.HotelFotografijeBaza.ToList()

            };


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile, Photos photos)
        {

         

            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            ApplicationDbContext fotografije = new ApplicationDbContext();
            fotografije.HotelFotografijeBaza.Add(new Photos
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes,
                HotelSobaId = photos.HotelSobaId
              
            });

            fotografije.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}