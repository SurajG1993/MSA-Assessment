using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nandoso.Models
{
    public class ForumTopic
    {
        public string Topic { get; set; }

        public virtual ICollection<ForumContent> content { get; set; } // Relational data to forum topic
    }
}