using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tech_Tips.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Blog Title")]
        public string Title { get; set; }
        [Display(Name = "Blog Description")]
        public string Description { get; set; }
        public Category Category { get; set; }
        public byte CategoryId { get; set; }
    }
}