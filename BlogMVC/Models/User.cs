using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}