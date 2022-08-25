using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key] //Key Attribute'u ilgili sütunun Primary Key olmasına yarar
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogScore { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogID { get; set; } //Blog Entity'deki ID
        public Blog Blog { get; set; } //Yorumun ait oldugu Blog. 1 Yorum, 1 Blog'a aittir. 1 to 1.

    }
}
