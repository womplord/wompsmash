using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wompsmash.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Uri Location { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}