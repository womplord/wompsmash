using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wompsmash.DAL;
using wompsmash.Models;
using PagedList;

namespace wompsmash.Controllers
{
    public class AuthorController : Controller
    {
        private WompSmashContext db = new WompSmashContext();

        // GET: Author
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_desc" : "first_name";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.EmailSortParm = sortOrder == "Email" ? "email_desc" : "Email";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var authors = from s in db.Author
                           select s;
            if(!String.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(s => s.LastName.Contains(searchString) ||
                    s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "last_name_desc":
                    authors = authors.OrderByDescending(s => s.LastName);
                    break;
                case "first_name":
                    authors = authors.OrderBy(s => s.FirstName);
                    break;
                case "first_name_desc":
                    authors = authors.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    authors = authors.OrderBy(s => s.DateAdded);
                    break;
                case "date_desc":
                    authors = authors.OrderByDescending(s => s.DateAdded);
                    break;
                case "Email":
                    authors = authors.OrderBy(s => s.Email);
                    break;
                case "email_desc":
                    authors = authors.OrderByDescending (s=>s.Email);
                    break;
                default:
                    authors = authors.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstName,Email")] Author author)
        {
            // try
            author.DateAdded = DateTime.Now;
            {
                if (ModelState.IsValid)
                {
                    db.Author.Add(author);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //catch(DataException)
            {
            //    ModelState.AddModelError("", "Unable to save changes.");
            }

            return View(author);
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var authorToUpdate = db.Author.Find(id);

            if (TryUpdateModel(authorToUpdate, "",
                new string[] {"LastName", "FirstMidName", "EnrollmentDate" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch(DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
            }
            return View(authorToUpdate);
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed";
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Author author = db.Author.Find(id);
                db.Author.Remove(author);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
