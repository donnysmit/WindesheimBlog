using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplicationPortfolioSite.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime CreatedLocalTime => this.Created.ToLocalTime();

        [MaxLength(230, ErrorMessage = "The title length is too long."), MinLength(5, ErrorMessage = "The title length is too short.")]
        public string Title { get; set; }

        [MaxLength(4096, ErrorMessage = "The message length is too long.")]
        public string Message { get; set; }

        [ForeignKey("BlogId")]
        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [JsonIgnore]
        [ForeignKey("BlogId")]
        public Blog Blog { get; set;  }

        [JsonIgnore]
        public Guid BlogId { get; set; }

        public DateTime Created { get; set; }

        public DateTime CreatedLocalTime => this.Created.ToLocalTime();

        [JsonIgnore]
        public string UserId { get; set; }

        [NotMapped]
        public string UserName { get; set; }

        [MaxLength(4096, ErrorMessage = "The message length is too long.")]
        public string Message { get; set; }
    }
}