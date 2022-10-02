using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.Models
{
    public class ServiceCategory: BaseEntity
    {
        public string Name{ get; set; }
        public List<Service> Services{ get; set; }
    }
}
