using System;
using System.ComponentModel.DataAnnotations;

namespace wompsmash.ViewModels
{
    public class AuthorDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        public int AuthorCount { get; set; }
    }
}