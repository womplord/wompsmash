using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wompsmash.DAL;
using wompsmash.ViewModels;
using wompsmash.Models;

namespace wompsmash.Controllers
{
    public class HomeController : Controller
    {
        private WompSmashContext db = new WompSmashContext();
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            IQueryable<AuthorDateGroup> data = from author in db.Author
                                               let dt = author.DateAdded
                                               group author by author.DateAdded into dateGroup
                                               select new AuthorDateGroup()
                                               {
                                                   DateAdded = dateGroup.Key,
                                                   AuthorCount = dateGroup.Count()
                                               };
            return View(data.ToList());
        }


        public void stuff()
        {
            Console.WriteLine("stuff");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}