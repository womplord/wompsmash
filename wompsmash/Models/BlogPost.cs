using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace wompsmash.Models
{
    public class BlogPost
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }
    }
}