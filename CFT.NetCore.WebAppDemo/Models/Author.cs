using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Email { get; set; }
    }
}
