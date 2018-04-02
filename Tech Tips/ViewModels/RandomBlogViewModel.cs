using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tech_Tips.Models;

namespace Tech_Tips.ViewModels
{
    public class RandomBlogViewModel
    {
        public Blog Blog { get; set; }
        public List<Article> Articles { get; set; }
    }
}