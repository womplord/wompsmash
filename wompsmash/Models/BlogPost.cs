using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wompsmash.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorID { get; set; }
    }
}