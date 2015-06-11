﻿using System;
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
        public string Location { get; set; }
        public int AuthorID { get; set; }
    }
}