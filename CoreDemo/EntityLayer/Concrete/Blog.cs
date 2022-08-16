using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key] //Key Attribute'u ilgili sütunun Primary Key olmasına yarar
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; } //Category tablosundaki CategoryID ile eşleşir. 
        public Category Category { get; set; } //Her Blog 1 Category'e aittir.  1 to 1. 
        public int WriterID { get; set; } 
        public Writer Writer { get; set; } //Her Blog 1 Writer'a aittir.  1 to 1. 
        public List<Comment> Comments { get; set; } //Bir Blog'da birden çok Comment olabilir.
    }
}
