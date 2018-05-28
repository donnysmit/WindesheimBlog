using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Post
    {
        public int ID { get; set; }

        [Display(Name = "Blog-titel")]
        [Required(ErrorMessage = "Mag niet leeg zijn")]
        public string Title { get; set; }

        [Display(Name = "Blog-inhoud")]
        [Required(ErrorMessage = "Mag niet leeg zijn")]
        public string Content { get; set; }

        [Display(Name = "Aangemaakt op")]
        public DateTime Created { get; set; }

        [Display(Name = "Aangemaakt door")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public Post()
        {
            Created = DateTime.Now;
        }
    }
}