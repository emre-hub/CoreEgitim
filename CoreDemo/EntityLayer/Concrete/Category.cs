using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //AccessModifierType DataType Name {get; set;}

        [Key] //Key Attribute'u ilgili sütunun Primary Key olmasına yarar
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Blog> Blogs { get; set; } //Bir Category türünde birden çok Blog olabilir. 1 to N 
    }
}
