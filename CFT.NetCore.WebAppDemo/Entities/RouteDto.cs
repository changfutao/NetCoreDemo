using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Entities
{
    public class RouteOneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RouteTwoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
