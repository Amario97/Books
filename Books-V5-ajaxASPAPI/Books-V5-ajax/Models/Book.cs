using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books_V5_ajax.Models
{
    public class Book
    {
        public string Id { get; set; }  
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
    }
}