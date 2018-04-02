using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tech_Tips.Models
{
    public class Category
    {
        public byte Id { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}