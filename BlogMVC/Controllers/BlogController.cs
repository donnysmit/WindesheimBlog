using BlogMVC;
using BlogMVC.Models;

namespace WebApplicationPortfolioSite.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using Microsoft.AspNet.Identity.Owin;
    using WebApplicationPortfolioSite.Models;

    [Authorize]
    public class BlogController : ApiController
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public BlogController()
        {
        }

        public BlogController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /* 
        // GET api/Blog
        [HttpGet]
        public BlogViewModel Get()
        {
            db.Blogs.Include(b => b.Comments).Load();
            return MakeSerializable(new BlogViewModel() { BlogMessages = db.Blogs.ToArray() });
        }

        // Get api/Blog/{id}
        [HttpGet]
        public BlogViewModel Get(Guid id)
        {
            db.Blogs.Include(b => b.Comments).Load();
            return MakeSerializable(new BlogViewModel() { BlogMessages = db.Blogs.Where(bm => bm.Id == id).ToArray() });
        }

        // Post api/Blog/{id}
        [HttpPost]
        public BlogViewModel Post(Guid id, [FromBody] CommentViewModel comment)
        {
            db.Blogs.Include(b => b.Comments).Load();
            var model = new BlogViewModel() { BlogMessages = db.Blogs.Where(bm => bm.Id == id).ToArray() };
            foreach (var blogMessage in model.BlogMessages)
            {
                blogMessage.Comments.Add(new Comment() {Message = comment.Comment, UserId = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name)?.Id, Created = DateTime.UtcNow });
            }

            db.SaveChanges();
            
            return MakeSerializable(model);
        } */

        private BlogViewModel MakeSerializable(BlogViewModel model)
        {
            model.BlogMessages = model.BlogMessages.OrderByDescending(b => b.Created).ToArray();
            foreach (var blogMessage in model.BlogMessages)
            {
                blogMessage.Comments = blogMessage.Comments.OrderByDescending(b => b.Created).ToList();
                foreach (var blogComment in blogMessage.Comments)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == blogComment.UserId);
                    blogComment.UserName = user == null ? "Unknown user" : user.UserName;
                }
            }

            return model;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}