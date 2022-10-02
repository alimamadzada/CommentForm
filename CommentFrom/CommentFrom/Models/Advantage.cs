using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.Models
{
    public class Advantage: BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
    }
}
