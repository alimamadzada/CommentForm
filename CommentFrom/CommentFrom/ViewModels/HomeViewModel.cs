using CommentFrom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.ViewModels
{
    public class HomeViewModel
    {
        public List<Service> Services { get; set; }
        public List<Advantage> Advantages { get; set; }
        public List<ServiceCategory> ServiceCategories { get; set; }
    }
}
