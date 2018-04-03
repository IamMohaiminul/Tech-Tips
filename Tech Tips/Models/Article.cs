using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tech_Tips.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Article Title")]
        public string Title { get; set; }
        [Display(Name = "Article Description")]
        public string Description { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Article Category")]
        public byte CategoryId { get; set; }
    }
}