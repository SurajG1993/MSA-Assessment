using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nandoso.Models
{
    public class ForumReplies
    {
        [Key]
        public int id {get; set;}
        public int postID { get; set; }
        public string userName { get; set; }
        public string reply { get; set; }
    }
}