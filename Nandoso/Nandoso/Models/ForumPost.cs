using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace Nandoso.Models
{
    public class ForumPost
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string post { get; set; }

        [JsonIgnore]
        public virtual ICollection<ForumReplies> reply { get; set; } // Relational data to forum topic
    }
}