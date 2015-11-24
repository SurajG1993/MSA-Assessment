using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Nandoso.Models
{
    public class MenuModel
    {
        [Key]
        public int id { get; set; }
        public string itemName { get; set; }
        public float itemPrice { get; set; }
    }
}