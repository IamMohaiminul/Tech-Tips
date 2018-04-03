using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tech_Tips.Models;

namespace Tech_Tips.ViewModels
{
    public class ArticleFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Article Article { get; set; }
    }
}