using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KickStartMVCDemo.Models
{
    public class Children
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string ChildType { get; set; }
    }
}