﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wompsmash.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
    }
}