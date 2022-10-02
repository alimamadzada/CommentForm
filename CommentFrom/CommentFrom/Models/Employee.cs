using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Img { get; set; }
    }
}
