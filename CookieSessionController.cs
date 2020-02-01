using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMART.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
namespace EMART.Controllers
{
    public class CookieSessionController : Controller
    {
        public readonly SellerContext _context;
        //public readonly BuyerContext _context1;
        //public readonly ProductContext _context2;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CookieSessionController(SellerContext context,  IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            //_context1 = context1;
            //_context2 = context2;
            this.hostingEnvironment = hostingEnvironment;
        }
       public ActionResult SIndex()
        {
            return View();
        }
        public ActionResult BIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddItems()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult AddItems(Product p)
        //{
        //    try
        //    {
        //        _context2.Add(p);
        //        _context2.SaveChanges();
        //        ViewBag.message = p.pname + " has got successfully Registerd";
        //        return RedirectToAction("Login");

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.message = p.pname + "Registration failed";
        //        return View();
        //    }

        //}
        [HttpGet]
        public ActionResult BuyerSignup()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult BuyerSignup(Buyer b)
        //{
        //    try
        //    {
        //        _context1.Add(b);
        //        _context1.SaveChanges();
        //        ViewBag.message = b.bname + " has got successfully Registerd";
        //        return RedirectToAction("Login");

        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.message = b.bname + "Registration failed";
        //        return View();
        //    }

        //}
        //[HttpGet]
        //public ActionResult BuyerLogin()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult BuyerLogin(Buyer b)
        //{
        //    var logUser = _context1.Buyers.Where(e => e.bid == b.bid && e.bpassword == b.bpassword).ToList();
        //    if (logUser.Count == 0)
        //    {
        //        ViewBag.message = "Not Valid User";
        //        return View();
        //    }
        //    else
        //    {//to store session values
        //        //HttpContext.Session.SetString("UName", s.sname);

        //        //HttpContext.Session.SetString("lastLogin", DateTime.Now.ToString());
        //        return RedirectToAction();
        //    }


        //}
        //// GET: CookieSession
        //[HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SellerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.PhotoPath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Seller newseller = new Seller
                {
                    
                    sname = model.sname,
                    spassword=model.spassword,
                    companyname=model.companyname,
                    gstin=model.gstin,
                    sphnum=model.sphnum,
                    semail = model.semail,
                    postal_address=model.postal_address,
                    ////Depar = model.Department,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    PhotoPath = uniqueFileName
                };

                _context.Add(newseller);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = newseller.sid });
            }

            return View();
            //try
            //{
            //    _context.Add(s);
            //    _context.SaveChanges();
            //    ViewBag.message = s.sname + " has got successfully Registerd";
            //    return RedirectToAction("Login");

            //}
            //catch (Exception e)
            //{
            //    ViewBag.message = s.sname + "Registration failed";
            //    return View();
            //}

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Seller s)
        {
            var logUser = _context.Sellers.Where(e => e.sid== s.sid && e.spassword == s.spassword).ToList();
            if (logUser.Count == 0)
            {
                ViewBag.message = "Not Valid User";
                return View();
            }
            else
            {//to store session values
                //HttpContext.Session.SetString("UName", s.sname);

                //HttpContext.Session.SetString("lastLogin", DateTime.Now.ToString());
                return RedirectToAction("AddItems");
            }


        }
        //public ActionResult SellerDashBoard()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            return View();
        }

        // GET: CookieSession/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CookieSession/Create
        
        // POST: CookieSession/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: CookieSession/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CookieSession/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CookieSession/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CookieSession/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}