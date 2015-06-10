using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wompsmash.Models;

namespace wompsmash.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var blogPost = new List<BlogPost>();

            if(Session["BlogPost"] != null)
            {
                blogPost.Add((BlogPost)Session["BlogPost"]);
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(BlogPost newBlogPost)
        {
            var blogPost = new List<BlogPost>();
            if(Session["BlogPost"] != null)
            {
                blogPost.Add((BlogPost)Session["BlogPost"]);
            }

            blogPost.Add(newBlogPost);
            Session["BlogPost"] = blogPost;
            return RedirectToAction("Index");
        }
    }
}