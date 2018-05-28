using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationPortfolioSite.Models
{
    // Models returned by MeController actions.
    public class BlogViewModel
    {
        public Blog[] BlogMessages { get; set; }
    }
}