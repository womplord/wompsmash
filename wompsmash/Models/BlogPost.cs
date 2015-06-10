using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wompsmash.Models
{
    public class BlogPost
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
    }
}