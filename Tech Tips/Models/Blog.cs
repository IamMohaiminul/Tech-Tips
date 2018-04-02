using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tech_Tips.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public byte CategoryId { get; set; }
    }
}